using LibraryApp.Models;
using LibraryApp.Services;
using LibraryApp.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class AdminController : Controller
    {
        private static string _secretKey = "0f8fad5b-d9cb-469f-a165-70867728950e";

        private readonly IBookService _bookService;

        public AdminController()
        {
            _bookService = new BookService();
        }

        public AdminController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            if (CheckPermission(Request))
            {
                AdminPanelViewModel _vm = new AdminPanelViewModel()
                {
                    Books = _bookService.GetAllBooks(),
                    Book = new Book()
                };
                return View(_vm);
            }
            else
            {
                ViewBag.Message = "Ошибка! Нет доступа!";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            if(CheckPermission(Request))
            {
                AdminPanelViewModel _vm = new AdminPanelViewModel()
                {
                    Book = new Book(),
                    Books = _bookService.GetBooks(searchString)
                };
                return View(_vm);
            }
            else
            {
                ViewBag.Message = "Нет доступа!";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterSecretKey(string secretKey)
        {
            if (!String.IsNullOrEmpty(secretKey))
            {
                if (secretKey == _secretKey)
                {
                    Response.Cookies.Add(CreateSecretKeyCookie());
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ключ неверный. Попробуйте еще!";
                    return RedirectToAction("Login");
                }

            }
            else
            {
                ViewBag.Message = "Введите ключ!";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            if (CheckPermission(Request))
            {
                if(ModelState.IsValid)
                {
                    _bookService.CreateBook(book);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ошибка валидации!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Message = "Нет доступа! Введите секретный ключ!";
                return RedirectToAction("Login");
            }
                
        }

        public ActionResult EditBook(int bookID)
        {
            if (CheckPermission(Request))
            {
                Book _book = _bookService.GetBook(bookID);
                if(_book != null)
                {
                    return PartialView("_EditBookModalPartial", _book);
                }
                else
                {
                    return Content("<div class=\"alert alert - danger\" role=\"alert\">Книга не найдена!</div>");
                }
            }
            else
            {
                return Content("<div class=\"alert alert - danger\" role=\"alert\">Нет доступа!</div>");
            }
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (CheckPermission(Request))
            {
                if(ModelState.IsValid)
                {
                    _bookService.UpdateBook(book);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ошибка валидации!";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ViewBag.Message = "Нет доступа! Введите секретный ключ!";
                return RedirectToAction("Login");
            }
                
        }

        public ActionResult DeleteBook(int bookID)
        {
            if (CheckPermission(Request))
            {
                _bookService.DeleteBook(bookID);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Нет доступа! Введите секретный ключ!";
                return RedirectToAction("Login");
            }
        }

        private bool CheckPermission(HttpRequestBase httpRequest)
        {
            HttpCookie _reqCookie = httpRequest.Cookies.Get("SecretKey");
            if (_reqCookie == null)
                return false;
            string _reqSecretKey = _reqCookie.Value;
            if (!String.IsNullOrEmpty(_reqSecretKey))
            {
                if (_reqSecretKey == _secretKey)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private HttpCookie CreateSecretKeyCookie()
        {
            HttpCookie _secretKeyCookie = new HttpCookie("SecretKey");
            _secretKeyCookie.Value = _secretKey;
            _secretKeyCookie.Expires = DateTime.Now.AddMonths(2);
            return _secretKeyCookie;
        }

        protected override void Dispose(bool disposing)
        {
            _bookService.Dispose();
            base.Dispose(disposing);
        }
    }
}