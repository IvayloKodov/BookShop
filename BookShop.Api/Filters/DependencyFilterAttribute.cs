using System.Threading.Tasks;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShop.Api.Filters
{
    /// <summary>
    /// Just an example how to create an attribute with dependency injection.
    /// </summary>
    public class DependencyFilterAttribute : TypeFilterAttribute
    {
        public DependencyFilterAttribute() : base(typeof(ValidateAuthorExistsFilterImpl))
        {
        }

        /// <summary>
        /// Just an inner filter attribute which doing the real job.
        /// </summary>
        private class ValidateAuthorExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IAuthorsService _authorsService;

            public ValidateAuthorExistsFilterImpl(IAuthorsService authorsService)
            {
                _authorsService = authorsService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context,
                ActionExecutionDelegate next)
            {
                // Import your logic here.

                await next();
            }
        }
    }
}
