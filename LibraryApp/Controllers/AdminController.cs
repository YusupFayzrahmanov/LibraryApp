using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class AdminController : Controller
    {
        public static string SecretKey = "0f8fad5b-d9cb-469f-a165-70867728950e";

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook()
        {
            return RedirectToAction("Index");
        }

        public ActionResult EditBook(int bookID)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditBook()
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int bookID)
        {
            return RedirectToAction("Index");
        }
    }
}