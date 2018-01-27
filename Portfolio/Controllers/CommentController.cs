using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<BlogUser> _userManager;

        public CommentController(AppDbContext db, UserManager<BlogUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // empty.
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
        public async Task<IActionResult> Create(Comment newComment)
        {
            
            newComment.CommentId = 0;
            newComment.Author = this.User.Identity.Name;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
				var currentUser = await _userManager.FindByIdAsync(userId); 
				newComment.User = currentUser;
            }
            _db.Comments.Add(newComment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Post");
            //return Json(newComment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromEntry(Comment newComment)
        {
            newComment.CommentId = 0;
            newComment.Author = this.User.Identity.Name;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var currentUser = await _userManager.FindByIdAsync(userId);
                newComment.User = currentUser;
            }
            _db.Comments.Add(newComment);
            _db.SaveChanges();  
            return RedirectToAction("Entry", "Post", new { id = newComment.PostId});
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            Comment thisComment = _db.Comments.FirstOrDefault(p => p.CommentId == id);
            _db.Comments.Remove(thisComment);
            _db.SaveChanges();
            return RedirectToAction("Entry", "Post", new { id = thisComment.PostId});
        }
    }
}
