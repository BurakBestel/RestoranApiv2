using Microsoft.AspNetCore.Mvc;

namespace RestoranApi22.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
