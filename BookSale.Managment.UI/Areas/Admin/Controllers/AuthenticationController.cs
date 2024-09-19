using BookSale.Managment.Application.IService;
using BookSale.Managment.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookSale.Managment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService) 
        {
            _userService = userService;
        }   

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
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                bool result =  await _userService.CheckLogin(loginModel.Username,loginModel.Password);

                if (!result) 
                {
                    ViewBag.Error = "Username or Password is Invalid";
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                List<string> error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                ViewBag.Error = string.Join("<br/>", error);
            }
            

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await _userService.Logout();
            return View("Login");
        }
    }
}
