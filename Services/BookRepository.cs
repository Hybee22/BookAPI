﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class BookRepository : IBookRepository
    {
        public bool BookExists(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool BookExists(string bookIsbn)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(string bookIsbn)
        {
            throw new NotImplementedException();
        }

        public decimal GetBookRating(int bookId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateISBN(int bookId, string bookIsbn)
        {
            throw new NotImplementedException();
        }
    }
}
