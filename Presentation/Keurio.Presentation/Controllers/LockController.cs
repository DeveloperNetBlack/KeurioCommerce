using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.Controllers
{
    public class LockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
