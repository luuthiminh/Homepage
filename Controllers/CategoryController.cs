using Homepage.Data;
using Homepage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Homepage.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeRequest(Category category, Request request)
        {
            if (ModelState.IsValid)
            {
                var cat = new Category();
                cat.CatId = request.CatId;
                cat.CatName = request.CatName;
                cat.CatDescription = request.CatDescription;
                cat.Status = request.Status;
                context.Categories.Add(cat);
                context.Requests.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add", request);
            }
            }
            public IActionResult IndexRequest()
            {
                return View(context.Requests.ToList());
            }

            public IActionResult Accept(int id)
            {
                var request = context.Requests.Find(id);
                foreach (var cat in context.Categories)
                {
                    if (cat.CatId.Equals(request.CatId))
                    {
                        cat.Status = 2;
                        context.Categories.Update(cat);
                    }
                }
                context.Requests.Remove(request);
                context.SaveChanges();
                return RedirectToAction("IndexRequest");
            }
            public IActionResult Reject(int id)
            {
                var request = context.Requests.Find(id);
                context.Requests.Remove(request);
                foreach (var cat in context.Categories)
                {
                    if (cat.CatId.Equals(request.CatId))
                    {
                        cat.Status = 3;
                        context.Categories.Update(cat);
                    }
                }
                context.SaveChanges();
                return RedirectToAction("IndexRequest");
            }
            [HttpGet]
            public IActionResult Edit(int id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    var category = context.Categories.Find(id);
                    return View(category);
                }
            }
            [HttpPost]
            public IActionResult Edit(Category category)
            {
                if (ModelState.IsValid)
                {
                    context.Categories.Update(category);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }
            }
            public IActionResult Delete(int id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    var category = context.Categories.Find(id);
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }
