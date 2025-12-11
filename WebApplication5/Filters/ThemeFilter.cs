using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication5.Filters
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var http = context.HttpContext;
            var theme = http.Request.Cookies["theme"] ?? "light";

          
            if (context.Controller is Controller controller)
            {
                controller.ViewBag.Theme = theme;
            }

            
            //http.Items["theme"] = theme;

            base.OnActionExecuting(context);
        }
    }
}
