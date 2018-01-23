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
            ManageRole manager = new ManageRole
            {
                BlogRoles = _db.Roles.ToList()
            };
            manager.SetSelectList();
            return View(manager);
        }
    }
}
