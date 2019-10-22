using LibraryApp.Services;
using LibraryApp.ViewModels;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController()
        {
            _bookService = new BookService();
        }

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            HomeViewModel _vm = new HomeViewModel()
            {
                Books = _bookService.GetAllBooks()
            };
            return View(_vm);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            HomeViewModel _vm = new HomeViewModel()
            {
                Books = _bookService.GetBooks(searchString)
            };
            return View(_vm);
        }

        protected override void Dispose(bool disposing)
        {
            _bookService.Dispose();
            base.Dispose(disposing);
        }
    }
}