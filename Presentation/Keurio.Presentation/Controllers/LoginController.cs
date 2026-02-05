using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AuthenticationIdentity");
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
