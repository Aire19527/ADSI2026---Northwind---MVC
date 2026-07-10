using Microsoft.AspNetCore.Mvc;

namespace ADSI2026.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
