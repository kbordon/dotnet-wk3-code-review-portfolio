using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using Portfolio.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class RoleController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<BlogUser> _userManager;
        private readonly SignInManager<BlogUser> _signInManager;
        private readonly RoleManager<BlogRole> _roleManager;

        public RoleController(UserManager<BlogUser> userManager, SignInManager<BlogUser> signInManager, RoleManager<BlogRole> roleManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }

        public IActionResult Index()
        {
            
            return View(_db.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRole registerRole)
        {
            
            BlogRole role = new BlogRole
            {
                Name = registerRole.RoleName
            };

            IdentityResult result = await _roleManager.CreateAsync(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Manage()
        {
            ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToUser(string UserName, string RoleName)
        {
            var user = _db.Users.Where(u => u.UserName == UserName).FirstOrDefault();
            await _userManager.AddToRoleAsync(user, RoleName);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                BlogUser user = _db.Users.Where(u => u.UserName == UserName).FirstOrDefault();
                if ( user != null)
                {
					ViewBag.RolesForThisUser = await _userManager.GetRolesAsync(user);   
                }
            }
            ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");
            return View("Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserRole(string UserName, string RoleName)
        {
            BlogUser user = _db.Users.Where(u => u.UserName == UserName).FirstOrDefault();
            if (await _userManager.IsInRoleAsync(user, RoleName))
            {
                await _userManager.RemoveFromRoleAsync(user, RoleName);
            }

            ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");
            return View("Manage");
        }
    }
}
