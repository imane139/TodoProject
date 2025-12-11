using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication5.Filters
{
    public class LogFilter:ActionFilterAttribute
    {

        private static readonly string logPath = "Logs/logs.txt";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.RouteData.Values["controller"]?.ToString() ?? "Unknown";
            string action = context.RouteData.Values["action"]?.ToString() ?? "Unknown";

            
            string user = context.HttpContext.Session.GetString("username") ?? "Anonymous";

            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  |  {user}  |  {controller}  |  {action}";

            Directory.CreateDirectory("Logs");
            File.AppendAllText("Logs/logs.txt", line + Environment.NewLine);

            base.OnActionExecuting(context);
        }
    }
}
