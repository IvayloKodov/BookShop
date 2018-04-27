using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShop.Api.Infrastructure.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(nameof(OnActionExecuting), (Controller)filterContext.Controller);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(nameof(OnActionExecuted), (Controller)filterContext.Controller);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log(nameof(OnResultExecuting), (Controller)filterContext.Controller);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log(nameof(OnResultExecuted), (Controller)filterContext.Controller);
        }

        private static void Log(string methodName, Controller controller)
        {
            var controllerName = controller.ControllerContext.ActionDescriptor.ControllerName;

            var actionName = controller.ControllerContext.ActionDescriptor.ActionName;

            var message = $"{methodName} controller:{controllerName} action:{actionName}";

            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}