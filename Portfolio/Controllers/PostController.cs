using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<BlogUser> _userManager;


        public PostController(UserManager<BlogUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Posts.Include(p => p.Comments));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Post newPost)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newPost.User = currentUser;
            _db.Posts.Add(newPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(p => p.PostId == id);
            return View(thisPost);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Post editPost)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            _db.Entry(editPost).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var thisPost = _db.Posts.FirstOrDefault(p => p.PostId == id);
            return View(thisPost);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == id);
            _db.Remove(thisPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
