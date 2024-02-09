using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Web.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoLayout()
        {

            return View();
        }
    }
}
