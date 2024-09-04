using Microsoft.AspNetCore.Mvc;

namespace BookSale.Managment.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
