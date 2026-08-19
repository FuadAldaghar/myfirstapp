using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}