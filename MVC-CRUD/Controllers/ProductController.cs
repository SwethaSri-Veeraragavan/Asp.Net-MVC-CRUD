using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Product> products = _db.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.TotalPrice = product.Quantity * Convert.ToDouble(product.Price);

                _db.Products.Add(product);
                _db.SaveChanges();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Update(int id)
        {
            var data = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
           
            if (ModelState.IsValid)
            {
                product.TotalPrice = product.Quantity * Convert.ToDouble(product.Price);

                _db.Products.Update(product);
                _db.SaveChanges();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
           
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var data = _db.Products.Find(id);        
            _db.Products.Remove(data);
            _db.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
            
            
        }
    }
}
