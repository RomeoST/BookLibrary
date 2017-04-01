using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        LibraryContext context = new LibraryContext();
        // GET: Book
        public ActionResult Index()
        {
            return View(context.Books.ToList());
        }
    }
}