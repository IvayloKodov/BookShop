using BookShop.Api.Configurations;
using BookShop.Services.Models.Authors;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using BookShop.Api.Infrastructure.Filters;
using BookShop.Api.Models;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{ 
    using static Constants.WebConstants;

    public class AuthorsController : BaseApiController
    {
        private readonly IAuthorsService _authorsService;
        private readonly ISmtpConfiguration _smtpConfiguration;

        public AuthorsController(IAuthorsService authorsService, IOptions<SmtpConfiguration> smtpOptions)
        {
            _authorsService = authorsService;
            _smtpConfiguration = smtpOptions.Value;
        }

        [HttpGet(WithId)]
        [ProducesResponseType(typeof(AuthorDetailsServiceModel), 200)]
        [ProducesResponseType(404)]
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
