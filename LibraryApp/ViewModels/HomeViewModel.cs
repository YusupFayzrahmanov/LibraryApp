using LibraryApp.Models;
using System.Collections.Generic;

namespace LibraryApp.ViewModels
{
    /// <summary>
    /// Модель представления главной страницы библиотеки
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// Коллекция книг библиотеки
        /// </summary>
        public IEnumerable<Book> Books { get; set; }
    }
}