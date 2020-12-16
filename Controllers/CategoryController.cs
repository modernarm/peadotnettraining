using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEADotNetTraining.Data;
using PEADotNetTraining.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
namespace PEADotNetTraining.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IActionResult> Index(string filter, int pageIndex = 1, string sortExpression = "CategoryId")
        {
            var query = _applicationDbContext.Category.AsNoTracking();
            if (!String.IsNullOrEmpty(filter))
            {
                query = query.Where(category => EF.Functions.Like(category.CategoryName,$"%{filter}%"));
            }
            ViewBag.count = await _applicationDbContext.Category.CountAsync();
            PagingList<Category> category = await PagingList.CreateAsync(query, 10, pageIndex, sortExpression, nameof(Category.CategoryId));

            category.RouteValue = new RouteValueDictionary
            {
                {"filter",filter }
            };
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

        public async Task<IActionResult> UpdateCategory(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _applicationDbContext.Category.FindAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (!ModelState.IsValid) return View(category);

            Category getCategory = await _applicationDbContext.Category.FindAsync(category.CategoryId);

            if (getCategory == null) return NotFound();

            getCategory = category;

            _applicationDbContext.Entry(getCategory).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            return View(category);
        }

    }
}
