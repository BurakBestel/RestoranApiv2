using Microsoft.AspNetCore.Mvc;

namespace ApiRestoranApiv2.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
