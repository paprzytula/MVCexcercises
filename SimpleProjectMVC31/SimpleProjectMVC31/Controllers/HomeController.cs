﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleProjectMVC31.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectMVC31.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        
    }
}