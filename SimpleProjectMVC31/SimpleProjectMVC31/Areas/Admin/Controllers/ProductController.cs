using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProjectMVC31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectMVC31.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private ShopContext context;
        private List<Category> categories;
        public ProductController(ShopContext context)
        {
            this.context = context;
            categories = context.Categories.OrderBy(c => c.CategoryId).ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        [Route("[area]/[controller]s/{id}")]
        public IActionResult List(string id = "All")
        {
            List<Product> products;
            if (id == "All")
            {
                products = context.Products.OrderBy(products => products.ProductId).ToList();
            }
            else
            {
                products = context.Products.Where(p => p.Category.Name == id).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            product.Category = context.Categories.Find(1);

            ViewBag.Action = "Add";
            ViewBag.Categories = categories;
            return View("AddUpdate", product);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)

                    context.Products.Add(product);
                else
                    context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(product => product.ProductId == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }

    }
}
