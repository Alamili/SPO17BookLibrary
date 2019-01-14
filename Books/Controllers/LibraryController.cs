using Books.Data.Entities;
using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Books.Controllers
{
    public class LibraryController : Controller
    {
        public ISqlService _db { get; set; }
        public LibraryController(ISqlService db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Get<Book>().ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(!ModelState.IsValid) return View(book);

            try
            {
                _db.Add(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(book);
            }
        }

        public IActionResult Details(int id)
        {                             
            var model = new AuthorBookDTO
            {
                Book = _db.Get<AuthorBook>()
                             .Include("Book")
                             .FirstOrDefault(ab => ab.BookId.Equals(id))
                             .Book,
                Authors = _db.Get<AuthorBook>()
                             .Include("Author")
                             .Where(ab => ab.BookId.Equals(id))
                             .Select(s => s.Author)
                             .ToList()
            };

            return View(model);
            //var authorBook = _db.Get<AuthorBook>()
            //    .Include("Author")
            //    .Include("Book")
            //    .Where(ab => ab.BookId.Equals(id));
            //return View(authorBook);
        }


    }
}