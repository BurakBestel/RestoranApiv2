using Microsoft.AspNetCore.Mvc;

namespace RestoranApi22.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _HeadLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
