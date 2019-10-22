using LibraryApp.Models;
using LibraryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(Book book)
        {
            _bookRepository.InsertBook(book);
            _bookRepository.Save();
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
            _bookRepository.Save();
        }

        public void DeleteBook(int bookID)
        {
            _bookRepository.DeleteBook(bookID);
            _bookRepository.Save();
        }

        public void EditBook(Book book)
        {
            _bookRepository.UpdateBook(book);
            _bookRepository.Save();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetBooks().ToList();
        }

        public Book GetBook(int bookID)
        {
            return _bookRepository.GetBook(bookID);
        }

        public IEnumerable<Book> GetBooks(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
                return _bookRepository.GetBooks()
                    .Where(x => x.Author.ToUpper().Contains(searchString.ToUpper())
                        || x.Name.ToUpper().Contains(searchString.ToUpper())
                        || x.PublishingHouse.ToUpper().Contains(searchString.ToUpper()))
                    .ToList();
            else
                return _bookRepository.GetBooks().ToList();
        }

        public void Dispose()
        {
            _bookRepository.Dispose();
        }

       
    }
}