using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsPortal.Data;
using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using NewsPortal.Areas.Admin.Models;

namespace NewsPortal.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _logger = logger;
            _context = context;
            this.userManager = userManager;
        }


        public IActionResult Privacy() {
            return View();
        }

        public IActionResult ContactUs() {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> CreateUser(UserModel model)
        {
            //do kushte
            var user = new IdentityUser { UserName = model.Username, Email = model.Username };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }

        public IActionResult SportNews(string search) {
            var news = _context.News.Where(cId => cId.CategoryId == 2).ToList();
            var searchedNews = new List<News>();
            if (search != null) {
                foreach (var n in news) {
                    if (n.Name.ToLower().Contains(search.ToLower())) {
                        searchedNews.Add(n);
                    }
                }
            }
            else {
                searchedNews = news;
            }
            return View(searchedNews);
        }


        public IActionResult ShowbizNews(string search) {
            var news = _context.News.Where(cId => cId.CategoryId == 3).ToList();
            var searchedNews = new List<News>();
            if (search != null) {
                foreach (var n in news) {
                    if (n.Name.ToLower().Contains(search.ToLower())) {
                        searchedNews.Add(n);
                    }
                }
            }
            else {
                searchedNews = news;
            }
            return View(searchedNews);
        }
        public IActionResult TeknologjiNews(string search) {
            var news = _context.News.Where(cId => cId.CategoryId == 4).ToList();
            var searchedNews = new List<News>();
            if (search != null) {
                foreach (var n in news) {
                    if (n.Name.ToLower().Contains(search.ToLower())) {
                        searchedNews.Add(n);
                    }
                }
            }
            else {
                searchedNews = news;
            }
            return View(searchedNews);
        }

        public ViewResult Index(string search) {
            var news = _context.News.ToList();
            var searchedNews = new List<News>();
            if (search != null) {
                foreach (var n in news) {
                    if (n.Name.ToLower().Contains(search.ToLower())) {
                        searchedNews.Add(n);
                    }
                }
            }
            else {
                searchedNews = news;
            }
            return View(searchedNews);
        }

        //public async Task<IActionResult> Index(string search) {
        //    var news = _context.News.ToList();
        //    var searchedNews = new List<News>();
        //    if (search != null) {
        //        foreach (var n in news) {
        //            if (n.Name.ToLower().Contains(search.ToLower())) {
        //                searchedNews.Add(n);
        //            }
        //        }
        //    }
        //    else {
        //        searchedNews = news;
        //    }
        //    return View(searchedNews);
        //}

        //pagination
        //public async Task<IActionResult> Index(string search, int pageNumber = 5, int pageSize = 2) {
        //    var news = _context.News.ToList();
        //    int ExcludeRecords = (pageSize * pageNumber) - pageSize;
        //    var searchedNews = new List<News>();
        //    if (search != null) {
        //        foreach (var n in news) {
        //            if (n.Name.ToLower().Contains(search.ToLower())) {
        //                searchedNews.Add(n);
        //            }
        //        }
        //    }
        //    else {
        //        searchedNews = news;
        //    }

        //    searchedNews.Skip(ExcludeRecords).Take(pageSize);
        //    var result = new PagedResult<News>
        //    {
        //        Data = searchedNews.ToList(),
        //        TotalItems = _context.News.Count(),
        //        PageNumber = pageNumber,
        //        PageSize = pageSize
        //    };
        //    return View(result);
        //}

        

       

        public async Task<IActionResult> NewsDetails(int Id) {

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (news == null) {
                return NotFound();
            }

            return View(news);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
