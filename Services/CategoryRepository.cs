using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private BookDbContext _categoryContext;

        public CategoryRepository(BookDbContext categoryContext, BookCategory bookCategory)
        {
            _categoryContext = categoryContext;
        }
        public bool CategoryExists(int categoryId)
        {
            return _categoryContext.Categories.Any(category => category.Id == categoryId);
        }

        public ICollection<Book> GetAllBooksForCategory(int categoryId)
        {
            return _categoryContext.BookCategories.Where(category => category.CategoryId == categoryId).Select(book => book.Book).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryContext.Categories.OrderBy(category => category.Name).ToList();
        }

        public ICollection<Category> GetAllCategoriesOfABook(int bookId)
        {
            return _categoryContext.BookCategories.Where(book => book.BookId == bookId).Select(category => category.Category).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryContext.Categories.Where(category => category.Id == categoryId).FirstOrDefault();
        }

    }
}