using Microsoft.AspNetCore.Mvc;

namespace RestoranApi22.WebUI.ViewComponents.DefaultMenuViewComponent
{
    public class _DefaultMenuViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
