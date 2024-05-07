using Microsoft.AspNetCore.Mvc;

namespace GG.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
