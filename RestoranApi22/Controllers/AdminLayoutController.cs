using Microsoft.AspNetCore.Mvc;

namespace RestoranApi22.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
