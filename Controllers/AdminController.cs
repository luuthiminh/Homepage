using Homepage.Data;
using Homepage.Migrations;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Homepage.Controllers
{
    public class AdminController : Controller
    {
        //attribute
        private readonly ApplicationDbContext context;

        //constructor (auto-generate : Alt+Enter => Generate constructor)
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View(context.Customers.ToList());
        }


        [HttpGet]
        public IActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(context.Customers.Find(id));
        }

        [HttpPost]
       /* public IActionResult EditCustomer(Customer cus)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Update(cus);
                context.SaveChanges();
                TempData["Message"] = "Edit student successfully !";
                // return RedirectToAction("index");
                return RedirectToAction(nameof(Customer));
            }
            else
            {
                return View(cus);
            }
        }*/

        public IActionResult DetailCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return View(context.Customers.Find(id));

            }
        }
        public IActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                //tìm ra object student có id được yêu cầu
                var cus = context.Customers.Find(id);
                //xóa object student vừa tìm thấy
                context.Customers.Remove(cus);
                //lưu lại thay đổi trong db
                context.SaveChanges();

                //gửi thông báo về trang Index
                //bắt buộc dùng TempData để có thể gửi dữ liệu về View nếu return RedirectToAction
                TempData["Message"] = "Delete student successfully !";

                //quay trở lại trang index sau khi thành công
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Customer));
            }
        }

        //StoreOwner
        public IActionResult StoreOwner()
        {
            return View(context.StoreOwners.ToList());
        }


        [HttpGet]
        public IActionResult EditStoreOwner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(context.StoreOwners.Find(id));
        }

        [HttpPost]
      /*  public IActionResult EditStoreOwner(StoreOwner storeowner)
        {
            if (ModelState.IsValid)
            {
                context.StoreOwners.Update(storeowner);
                context.SaveChanges();
                TempData["Message"] = "Edit student successfully !";
                // return RedirectToAction("index");
                return RedirectToAction(nameof(StoreOwner));
            }
            else
            {
                return View(storeowner);
            }
        }
*/

        public IActionResult DetailStoreOwner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return View(context.StoreOwners.Find(id));

            }
        }
        public IActionResult DeleteStoreOwner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                //tìm ra object student có id được yêu cầu
                var storeowner = context.StoreOwners.Find(id);
                //xóa object student vừa tìm thấy
                context.StoreOwners.Remove(storeowner);
                //lưu lại thay đổi trong db
                context.SaveChanges();

                //gửi thông báo về trang Index
                //bắt buộc dùng TempData để có thể gửi dữ liệu về View nếu return RedirectToAction
                TempData["Message"] = "Delete student successfully !";

                //quay trở lại trang index sau khi thành công
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(StoreOwner));
            }
        }
    }
 }
