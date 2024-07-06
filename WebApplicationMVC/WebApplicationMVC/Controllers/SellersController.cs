using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
