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
            var test = context.Books.ToList();
            return View(context.Books.ToList());
        }

        // GET : Book/Edit
        public ActionResult Edit(int id = -1)
        {
            var Book = context.Books.Find(id);
            if (Book == null)
                return new HttpNotFoundResult();

            return View(Book);
        }


        // GET : Book/Add
        public ActionResult Add()
        {
            var list = new List<SelectListItem>();
            foreach(var item in context.Authors.Select(p => p.FullName))
            {
                list.Add(new SelectListItem() { Text = item });
            }
            ViewBag.Authors = list;
            return PartialView();
        }

        // TODO: отправить свой JSON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(Book book, string selectAuthor)
        {
            if (book == null) return null;
            var Author = context.Authors.First(p => p.FullName == selectAuthor);
            if (Author == null) return null;

            Author.Books.Add(book);

            context.SaveChanges();

            Book b = new Book();
            b.Name = book.Name;
            b.Id = book.Id;
            b.Author = new Author { FullName = book.Author.FullName };

            var test = Json(b, JsonRequestBehavior.AllowGet);

            return Json(b, JsonRequestBehavior.AllowGet);
        }
    }
}