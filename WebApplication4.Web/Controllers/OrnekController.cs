using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Web.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
