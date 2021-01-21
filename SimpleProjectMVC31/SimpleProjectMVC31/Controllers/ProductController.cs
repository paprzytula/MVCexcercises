using Microsoft.AspNetCore.Mvc;
using SimpleProjectMVC31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectMVC31.Controllers
{
    public class ProductController : Controller
    {
        ShopContext context;
        public ProductController(ShopContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Products");
        }
        public IActionResult Detail(int id)
        {
            var categories = context.Categories.OrderBy(c => c.CategoryId).ToList();
            Product product = context.Products.Find(id);
            var categoryName = "";
            foreach (var cat in categories)
            {
                if (cat.CategoryId == product.CategoryId)
                {
                    categoryName = cat.Name;
                }
            }
            string imageFileName = product.Code + "-m.jpg";
            ViewBag.CategoryName = categoryName;
            ViewBag.ImageFileName = imageFileName;
            return View(product);
        }
        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories.OrderBy(c => c.Name).ToList();
            List<Product> products;
            if (id == "All")
            {
                products = context.Products.OrderBy(p => p.ProductId).ToList();
            }
            else if (id=="Specials")
            {
                products = context.Products.Where(p => p.Price < 5.0m).OrderBy(p => p.Name).ToList();
            }
            else
                products = context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductId).ToList();

            var model = new ProductListViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };
            return View(model);
        }
    }
}
