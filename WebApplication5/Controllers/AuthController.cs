using Microsoft.AspNetCore.Mvc;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class AuthController : Controller
    {
      

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(AuthVM vm)
        {
            if (vm.Nom == "admin" && vm.Password == "admin")
            {
                HttpContext.Session.SetString("isAuth", "true");
                HttpContext.Session.SetString("username", vm.Nom);
                return RedirectToAction("Index", "Todo");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("isAuth");
           
            return RedirectToAction("Login");
        }


    }
}
