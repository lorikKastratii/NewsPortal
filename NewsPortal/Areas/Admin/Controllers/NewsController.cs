using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;
using NewsPortal.Areas.Admin.Models;
using NewsPortal.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NewsPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public NewsController(ApplicationDbContext context, CategoryRepository categoryRepository,IWebHostEnvironment hostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

      

        //public async Task<IActionResult> GetNews() {
        //    return View("News",await _context.News.ToListAsync());
        //}

        // GET: Admin/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Admin/News/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageFile,Category,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,CategoryId")] News news)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/news/img
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                string extension = Path.GetExtension(news.ImageFile.FileName);
                news.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/News/img", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create)) {
                    await news.ImageFile.CopyToAsync(fileStream);
                }


                news.CreatedDate = DateTime.Now;
                news.UpdatedDate = DateTime.Now;
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: Admin/News/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            
            if (id == null)
            {
                return NotFound();
            }


            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageFile,Category,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,CategoryId")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                        //Save image to wwwroot/news/img
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                        string extension = Path.GetExtension(news.ImageFile.FileName);
                        news.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/News/img", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create)) {
                        await news.ImageFile.CopyToAsync(fileStream);
                    }
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: Admin/News/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Admin/News/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }

        
    }
}
