using ClassroomManagement.web.Infrstructure;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ClassroomManagement.web.Models;

namespace ClassroomManagement.web.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly DbObject _dbObject;

        public readonly IConfiguration _config;

        public AuthServices(DbObject dbObject, IConfiguration config)
        {
            _dbObject = dbObject;
            _config = config;
        }


        public async Task<ServiceResponse<string>> Login(string Email, string Password)
        {
            var response = new ServiceResponse<string>();
            var request = await _dbObject.UserTB.FirstOrDefaultAsync(u => u.Email.ToLower() == Email.ToLower());
            //User name auth validation
            if (request == null)
            {
                response.Success = false;
                response.Message = "Email not found!";
                new Error(response.Message + " Email = " + Email + " is not present in Database");
            }
            //Password auth 
            else if (!VerifyPasswordHash(Password, request.PasswordHash, request.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
                new Error(response.Message + " Email = " + Email + " present in Database. But Password did not match");
            }
            else
            {
                response.Message = "Logged In";
                response.Data = CreateToken(request);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string Password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserAlreadyExist(user.Email))
            {
                response.Success = false;
                response.Message = "User Already Exists";
                return response;
            }
            CreatePasswordHash(Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            user.PasswordSalt = PasswordSalt;
            user.PasswordHash = PasswordHash;

            _dbObject.UserTB.Add(user);
            await _dbObject.SaveChangesAsync();

            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserAlreadyExist(string Email)
        {
            if (await _dbObject.UserTB.AnyAsync(u => u.Email.ToLower() == Email.ToLower()))
            {
                return true;
            }
            new Error("User already exists");
            return false;
        }

        private void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        private bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return (ComputeHash.SequenceEqual(PasswordHash));
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };
            SymmetricSecurityKey Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            SigningCredentials Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = (DateTime.Now.AddMinutes(15)),
                SigningCredentials = Creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
