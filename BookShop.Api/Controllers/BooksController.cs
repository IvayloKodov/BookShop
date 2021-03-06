﻿using System.Threading.Tasks; 
using BookShop.Api.Infrastructure.Filters;
using BookShop.Api.Models;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using static BookShop.Api.Constants.WebConstants;

namespace BookShop.Api.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly ICachedBooksService _booksService;
        private readonly IAuthorsService _authorsService;

        public BooksController(ICachedBooksService booksService, IAuthorsService authorsService)
        {
            _booksService = booksService;
            _authorsService = authorsService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
        {
            return this.OkOrNotFound(await _booksService.BookDetailsAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            return this.OkOrNotFound(await _booksService.SearchAsync(search));
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody]PostBookRequestModel model)
        {
            if (!await _authorsService.ExistsAsync(model.AuthorId))
            {
                return BadRequest($"Author with id-{model.AuthorId} doesn't exist.");
            }

            return this.Ok(await _booksService.CreateAsync(model.AuthorId, model.Title, model.Description, model.Price, model.Copies, model.Edition, model.AgeRestriction, model.ReleaseDate, model.Categories));
        }
    }
}