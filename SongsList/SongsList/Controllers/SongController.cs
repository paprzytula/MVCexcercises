using Microsoft.AspNetCore.Mvc;
using SongsList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Controllers
{
    public class SongController : Controller
    {
        private SongContext Context { get; set; }
        public SongController(SongContext songContext)
        {
            Context = songContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
            return View("Edit", new Song());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
            var song = Context.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Edit( Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.SongId==0)
                {
                    Context.Songs.Add(song);
                }
                else
                {
                    Context.Songs.Update(song);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = song.SongId == 0 ? "Add" : "Edit";
                ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
                return View(song);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var song = Context.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
                    Context.Songs.Remove(song);
                    Context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
