﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Services.Models.Authors;
using BookShop.Services.Models.Books;

namespace BookShop.Services.Interfaces
{
    public interface IAuthorsService
    {
        Task<AuthorDetailsServiceModel> DetailsAsync(int authorId);
        Task<int> CreateAsync(string firstName, string lastName);
        Task<bool> Exists(int authorId);
        Task<IEnumerable<BooksByAuthorServiceModel>> GetBooks(int authorId);
    }
}