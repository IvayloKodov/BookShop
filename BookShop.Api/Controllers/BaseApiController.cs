namespace BookShop.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public abstract class BaseApiController : Controller
    {
        protected virtual IActionResult OkOrNotFound(object value)
        {
            if (value == null)
            {
                return new NotFoundObjectResult(value);
            }

            return new OkObjectResult(value);
        }
    }
}