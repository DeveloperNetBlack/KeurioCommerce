using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
