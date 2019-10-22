using LibraryApp.Models;
using LibraryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LibraryApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IBookRepository _bookRepository;

        public MvcApplication()
        {
            _bookRepository = new BookRepository();
        }

        protected void Application_Start()
        {
            SeedData();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            _bookRepository.Dispose();
        }

        private void SeedData()
        {
            List<Book> _books = new List<Book>()
            {
                new Book()
                {
                    Author = "А. С. Пушкин",
                    Name = "Евгений Онегин",
                    PublishingHouse="Веди",
                    Year = new DateTime(2000,01,12,00,00,00),
                    Description = "text text"
                },
                new Book()
                {
                    Author= "А. П. Чехов",
                    Name = "Дом с мезонимом",
                    PublishingHouse = "Веди",
                    Year = new DateTime(2000,01,12,00,00,00),
                    Description = "text text"
                }
            };
            _bookRepository.SeedData(_books);
            _bookRepository.Save();
        }
    }
}
