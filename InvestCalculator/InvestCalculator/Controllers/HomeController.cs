using InvestCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InvestCalculator.Controllers
{
    public class HomeController : Controller
    {
        public CultureInfo currency = new CultureInfo("fr-FR", false);
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FutureValue = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(FutureValueModel fv)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FutureValue = fv.Calculate().ToString("c2", currency);
            }
            else
            {
                ViewBag.FutureValue = "";
            }
            return View();
        }
    }
}
