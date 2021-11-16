using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class FreeSiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
