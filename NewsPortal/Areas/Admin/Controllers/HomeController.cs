using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Areas.Admin.Controllers {
    [Authorize]
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller {

       private readonly ApplicationDbContext _context;

        public HomeController (ApplicationDbContext context) {
            _context = context;
        }


        public IActionResult Index() {
            return View();
        }

        public IActionResult Users() {
            return View(_context.Users.ToList()); 
        }
    

    }
}
