using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.DTOs;
using BookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // api/categories
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category_DTO>))]
        public IActionResult GetCategories()
        {
            var categories =  _categoryRepository.GetCategories().ToList();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoriesDTO = new List<Category_DTO>();

            foreach(var category in categories )
            {
                categoriesDTO.Add(new Category_DTO { Id = category.Id, Name = category.Name });
            };

            return Ok(categoriesDTO);
        }


        // api/categories/categoryId
        [HttpGet("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Category_DTO))]
        public IActionResult GetCategory(int categoryId)
        {
            // if (!_categoryRepository.CategoryExists(categoryId))
                // return NotFound();

            var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryDTO = new Category_DTO() 
            {
                Id = category.Id, 
                Name = category.Name 
            };

            return Ok(categoryDTO);
        }


        // api/categories/books/bookId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category_DTO>))]
        public IActionResult GetAllCategoriesOfABook(int bookId)
        {
            var categories = _categoryRepository.GetAllCategoriesOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest();

            var categoriesDTO = new List<Category_DTO>();

            foreach (var category in categories)
            {
                categoriesDTO.Add(new Category_DTO { Id = category.Id, Name = category.Name });
            };

            return Ok(categoriesDTO);
        }



        // api/categories/categoryId/books
        [HttpGet("{categoryId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book_DTO>))]
        public IActionResult GetAllBooksForCategory(int categoryId)
        {
            var books = _categoryRepository.GetAllBooksForCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest();

            var booksDTO = new List<Book_DTO>();

            foreach (var book in books)
            {
                booksDTO.Add(new Book_DTO { Id = book.Id, Title = book.Title, Isbn = book.Isbn, DatePublished = book.DatePublished });
            };

            return Ok(booksDTO);
        }

    }
}