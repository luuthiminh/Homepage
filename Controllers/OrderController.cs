using Homepage.Data;
using Homepage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Homepage.Controllers
{
    public class OrderController : Controller
    {
        protected ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order_Book(int id, int quantity)
        {
            Order order = new Order();
            var books = context.Books.Find(id);
            order.Book = books;
            order.BookId = id;
            order.Price = books.Price * quantity;
            order.Date = System.DateTime.Now;
            order.Customer = "Minh";
            order.Quantity = quantity;
            books.Quantity -= quantity;
            context.Orders.Add(order);
            context.SaveChanges();
        
            return View(context.Orders.ToList());
        }
        public IActionResult List()
        {
            return View(context.Orders.ToList());
        }
    }
}
