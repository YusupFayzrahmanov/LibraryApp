using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Repositories
{
    public interface IBookRepository:IDisposable
    {

        /// <summary>
        /// Заполнить бд
        /// </summary>
        /// <param name="books"></param>
        void SeedData(IEnumerable<Book> books);

        /// <summary>
        /// Метод получения всех книг
        /// </summary>
        /// <returns></returns>
        IQueryable<Book> GetBooks();

        /// <summary>
        /// Получение книги по идентификатору
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        Book GetBook(int bookID);

        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="book"></param>
        void InsertBook(Book book);

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="bookID"></param>
        void DeleteBook(int bookID);

        /// <summary>
        /// Обновление книги
        /// </summary>
        /// <param name="book"></param>
        void UpdateBook(Book book);

        /// <summary>
        /// Сохранение
        /// </summary>
        void Save();
    }
}
