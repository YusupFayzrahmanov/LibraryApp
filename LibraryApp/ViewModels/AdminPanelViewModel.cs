using LibraryApp.Models;
using System.Collections.Generic;

namespace LibraryApp.ViewModels
{
    /// <summary>
    /// Модель представления панели администратора
    /// </summary>
    public class AdminPanelViewModel
    {
        /// <summary>
        /// Коллекция книг
        /// </summary>
        public IEnumerable<Book> Books { get; set; }
        
        /// <summary>
        /// Книга
        /// </summary>
        public Book Book { get; set; }
    }
}