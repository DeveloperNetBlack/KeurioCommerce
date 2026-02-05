using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.Areas.Security.Controllers
{
    [Area("Security")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("UserIndex");
        }
    }
}
