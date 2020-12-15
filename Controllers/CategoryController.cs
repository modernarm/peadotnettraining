using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEADotNetTraining.Data;
using PEADotNetTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEADotNetTraining.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> category = await _applicationDbContext.Category.OrderByDescending(x =>x.CategoryId).AsNoTracking().ToListAsync();
            ViewBag.count = await _applicationDbContext.Category.CountAsync();
            //return Ok(new { data = category });
            return View(category);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            await _applicationDbContext.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _applicationDbContext.Category.FindAsync(id);

            if (category == null) return NotFound();

            _applicationDbContext.Remove(category);
            await _applicationDbContext.SaveChangesAsync();
            TempData["feedback"] = "ลบข้อมูลเรียบร้อย";

            return RedirectToAction(nameof(Index));
        }
    }
}
