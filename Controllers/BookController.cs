using Homepage.Data;
using Homepage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.WebSockets;

namespace Homepage.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }
        public IActionResult Detail(int id)
        {
          /*  var book = context.Books.Find(id);*/
            var book = context.Books
                                 .Include(s => s.Category)
                                 .FirstOrDefault(s => s.Id == id);
            return View(book);
        }
  
        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var books = context.Books.Where(p => p.BookTitle.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No product found !";
            }
            return View("Index", books);
        }
        public IActionResult SorPriceAsc()
        {
            return View("Index", context.Books.OrderBy(s => s.BookPrice).ToList());
        }

        public IActionResult SortPriceDesc()
        {
            return View("Index", context.Books.OrderByDescending(s => s.BookPrice).ToList());
        }
        public IActionResult StoreOwner()
        {
            var categories = context.Categories.ToList();
            return View(context.Books.ToList());
        }
        public IActionResult Delete(int? id)
        {
            var book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(context.Books.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }
        public IActionResult Feedback()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
    }
}

