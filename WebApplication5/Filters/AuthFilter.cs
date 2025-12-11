using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication5.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var user = context.HttpContext.Session.GetString("isAuth");

            if (string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectToActionResult("login", "Auth", null);
            }
         


        }
    }
}
