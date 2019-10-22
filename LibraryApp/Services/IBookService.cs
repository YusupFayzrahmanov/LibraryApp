using LibraryApp.Models;
using System.Collections.Generic;

namespace LibraryApp.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        IEnumerable<Book> GetBooks(string searchString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        Book GetBook(int bookID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        void CreateBook(Book book);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        void UpdateBook(Book book);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        void EditBook(Book book);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        void DeleteBook(int bookID);

        /// <summary>
        /// 
        /// </summary>
        void Dispose();

    }
}
