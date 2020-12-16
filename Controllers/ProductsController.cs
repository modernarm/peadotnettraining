using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PEADotNetTraining.Data;
using PEADotNetTraining.Models;
using PEADotNetTraining.ViewModels;

namespace PEADotNetTraining
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public async Task<SelectList> GenerateCategorySelectList()
        {
            return new SelectList(await _context.Category.ToListAsync(), "CategoryId", "CategoryName");
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                CategoryList = await GenerateCategorySelectList()
            };
            return View(productViewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductPrice,ProductImage,ProductExpire,CategoryId")] ProductViewModel product, IFormFile ProductImage)
        {
            if (ModelState.IsValid)
            {
       
                if (ProductImage != null && ProductImage.Length > 0)
                {
                    string ext = Path.GetExtension(ProductImage.FileName);
                    string[] allowExt = { ".jpg", ".png", "jpeg" };
                    if (!allowExt.Contains(ext))
                    {
                        return BadRequest("กรุณาเลือกไฟล์ภาพนามสกุล .jpg, .png, .jpeg");
                    }

                    if(ProductImage.Length > 102400)
                    {
                        return BadRequest("ขนาดไฟล์มีความใหญ่เกินกว่า 10 mb");
                    }


                    string newFileName = Path.GetFileName(Guid.NewGuid().ToString()) + ext;
                    string fullPath = Path.Combine(_hosting.WebRootPath, "upload", newFileName);

                    using (var stream = new FileStream(fullPath, FileMode.CreateNew))
                    {
                        await ProductImage.CopyToAsync(stream);
                    }
                    ProductViewModel productViewModel = new ProductViewModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductExpire = product.ProductExpire,
                        ProductImage = newFileName,
                        CategoryId = product.CategoryId
                    };

                    await _context.AddAsync(productViewModel);
                }
                else
                {
                    await _context.AddAsync(product);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductViewModel productViewModel = new ProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage,
                ProductExpire = product.ProductExpire,
                CategoryList = await GenerateCategorySelectList()
            };
            return View(productViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductPrice,ProductImage,ProductExpire,CategoryId")] ProductViewModel product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ProductViewModel productViewModel = new ProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage,
                ProductExpire = product.ProductExpire,
                CategoryList = await GenerateCategorySelectList()
            };
            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
