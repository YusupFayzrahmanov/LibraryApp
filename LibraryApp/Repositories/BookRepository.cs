using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibraryApp.Repositories
{
    public class BookRepository:IBookRepository, IDisposable
    {
        private readonly LibraryContext _context;

        public BookRepository()
        {
            _context = new LibraryContext();
        }


        public void SeedData(IEnumerable<Book> books)
        {
            _context.Books.AddRange(books);
        }

        public IQueryable<Book> GetBooks()
        {
            return _context.Books;
        }

        public Book GetBook(int bookID)
        {
            return _context.Books.Find(bookID);
        }

        public void InsertBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void DeleteBook(int bookID)
        {
            Book book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}