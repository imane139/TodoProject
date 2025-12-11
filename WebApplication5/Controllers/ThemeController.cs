using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Change(string mode)
        {
            // Vérifier la valeur
            if (mode != "dark" && mode != "light")
                mode = "light";

            // Ajouter cookie valable 30 jours
            Response.Cookies.Append("theme", mode, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = false,
                Secure = false
            });

            // Retourner à la page précédente
            string? returnUrl = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Todo");
        }
    }
}
