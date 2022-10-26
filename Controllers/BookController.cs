using Homepage.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var book = context.Books.Find(id);
            return View(book);
        }
        public IActionResult Homepage()
        {
            return View(context.Books.ToList());
        }
        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var books = context.Books.Where(p => p.Title.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No product found !";
            }
            return View("Index", books);
        }
        public IActionResult SorPriceAsc()
        {
            return View("Index", context.Books.OrderBy(s => s.Price).ToList());
        }

        public IActionResult SortPriceDesc()
        {
            return View("Index", context.Books.OrderByDescending(s => s.Price).ToList());
        }
    }
}

