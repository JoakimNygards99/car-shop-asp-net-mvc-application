using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
