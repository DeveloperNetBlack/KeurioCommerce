using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.Areas.Purchase.Controllers
{
    [Area("Purchase")]
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View("SupplierIndex");
        }
    }
}
