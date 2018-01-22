using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _db;

        public CommentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            Comment newComment = new Comment { PostId = id }; 
            return View(newComment);
        }

        [HttpPost]
        public IActionResult Create(Comment newComment)
        {
            newComment.CommentId = 0;
            _db.Comments.Add(newComment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Post");
            //return Json(newComment);
        }

        [HttpPost]
        public IActionResult CreateFromEntry(Comment newComment)
        {
            newComment.CommentId = 0;
            _db.Comments.Add(newComment);
            _db.SaveChanges();  
            Console.WriteLine("###################### "+ newComment.PostId + " ##########################");
            return RedirectToAction("Entry", "Post", new { id = newComment.PostId});
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Comment thisComment = _db.Comments.FirstOrDefault(p => p.CommentId == id);
            _db.Comments.Remove(thisComment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }
    }
}
