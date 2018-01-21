using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

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
            _db.Comments.Add(newComment);
            _db.SaveChanges();
            return View("~/Post/Index");
        }
    }
}
