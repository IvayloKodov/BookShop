using System.Threading.Tasks;
using BookShop.Api.Constants;
using BookShop.Api.Infrastructure.Extensions;
using BookShop.Api.Infrastructure.Filters;
using BookShop.Api.Models;
using BookShop.Services.Interfaces;

namespace BookShop.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    public class AuthorsController : BaseApiController
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await _authorsService.DetailsAsync(id)); 

        [HttpGet(WithId + "/books")]
        public async Task<IActionResult> GetBooks(int id)
            => this.OkOrNotFound(await _authorsService.GetBooksAsync(id));
         
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]PostAuthorRequestModel model)
            => this.Ok(await _authorsService.CreateAsync(model.FirstName, model.LastName));
    }
}
