using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection objconn;
            SqlCommand objcmd;
            int i;
            objconn = new SqlConnection("Server=LAPTOP-T0V7LECG\\SQLEXPRESS;Database=ADO;Trusted_Connection=true");
            objconn.Open();
            try
            {

                objcmd = new SqlCommand("insert into Student values(@p1,@p2,@p3,@p4)", objconn);
                objcmd.Parameters.AddWithValue("@p1", 02);
                objcmd.Parameters.AddWithValue("@p2", "Abhisekh");
                objcmd.Parameters.AddWithValue("@p3", "JAVA");
                objcmd.Parameters.AddWithValue("@p4", 90);
                i = objcmd.ExecuteNonQuery();
                if (i != 0)
                    Console.WriteLine("Query executed successfully");
                else
                    Console.WriteLine("Error in query/ connection");

            }
            catch (SqlException se) { Console.WriteLine("Error Message " + se.Message); }
            finally
            {
                objconn.Close();
            }
        }
    }
}
