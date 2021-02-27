using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Areas.Admin.Controllers {
    [Area("Admin")]
    public class UserController : Controller {

        private readonly UserManager<IdentityUser> userManager;

        public UserController (UserManager<IdentityUser> context) {
            userManager = context;
        }


        [HttpGet]
        public IActionResult Index() {
            return View(userManager.Users);
        }

       
    }
}
