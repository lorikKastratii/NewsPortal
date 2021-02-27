using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Areas.Moderator.Controllers {
    [Area("Moderator")]
    public class HomeController : Controller {
        
        public IActionResult Dashboard() {
            return View();
        }

        
    }
}
