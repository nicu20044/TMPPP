using Microsoft.AspNetCore.Mvc;

namespace TMPPP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}