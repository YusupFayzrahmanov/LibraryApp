using System.Data.Entity;

namespace LibraryApp.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class LibraryContext:DbContext
    {
        public LibraryContext()
           : base("DefaultConnection")
        { }

        /// <summary>
        /// Книги
        /// </summary>
        public DbSet<Book> Books { get; set; }
    }
}