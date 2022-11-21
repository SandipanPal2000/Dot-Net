using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class AddController : Controller
    {
        public IActionResult GetNum()
        {
            return View();
        }
        public IActionResult SetNum(int x, int y)
        {
            Add obj= new Add();
            obj.x = x;
            obj.y = y;
            obj.sum = x + y;
            return View(obj);
        }
        
    }
}
