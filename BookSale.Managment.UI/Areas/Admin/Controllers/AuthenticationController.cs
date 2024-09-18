using BookSale.Managment.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookSale.Managment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

            }

            return View(loginModel);
        }
    }
}
