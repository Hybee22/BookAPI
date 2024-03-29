﻿using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        ICollection<Category> GetAllCategoriesOfABook(int bookId);
        ICollection<Book> GetAllBooksForCategory(int categoryId);
        bool CategoryExists(int categoryId);
    }
}
