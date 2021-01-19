using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoutingPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home");
        }

        public IActionResult About()
        {
            return Content("About");
        }

        public IActionResult Display (string id)
        {
            if (id==null)
            {
                return Content("No id supplied");
            }
            else
            {
                return Content("Id is " + id);
            }
        }
        [Route("[action]/{id?}")]
        public IActionResult Countdown(int id = 0)
        {
            string contentString = "Counting down: \n";
            for (int i = id; i >= 0; i--)
            {
                contentString += i + "\n";


            }
            return Content(contentString);
        }
    }
}
