using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SongsList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Controllers
{
    public class HomeController : Controller
    {
        private SongContext Context { get; set; }
        public HomeController(SongContext ctx)
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var songs = Context.Songs.Include(m => m.Genre)
                .OrderBy(m => m.Name)
                .ToList();
            return View(songs);
        } 
    }
}
