using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _db;
        public IActionResult Index()
        {
            return View();
        }
    }
}
