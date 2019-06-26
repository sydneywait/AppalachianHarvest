using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppalachianHarvest.Data;
using AppalachianHarvest.Models;
using AppalachianHarvest.Models.ViewModels;
using System.IO;

namespace AppalachianHarvest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.Producer).Include(p => p.ProductType).Include(p => p.Shelf);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Producer)
                .Include(p => p.ProductType)
                .Include(p => p.Shelf)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            CreateEditProductViewModel productModel = new CreateEditProductViewModel();

            productModel.Producers = new SelectList(_context.Set<Producer>(), "ProducerId", "BusinessName");
            productModel.ProductTypes = new SelectList(_context.Set<ProductType>(), "ProductTypeId", "Description");
            productModel.Shelves = new SelectList(_context.Set<Shelf>(), "ShelfId", "Description");
            return View(productModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditProductViewModel productModel)
        {
            if (ModelState.IsValid)
            {

                if (productModel.Product.ImageUpload!= null)
                {
                    //Store the image in a temp location as it comes back from the uploader
                    using (var memoryStream = new MemoryStream())
                    {
                        await productModel.Product.ImageUpload.CopyToAsync(memoryStream);
                        productModel.Product.Image = memoryStream.ToArray();
                    }
                }

                _context.Add(productModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            productModel.Producers = new SelectList(_context.Set<Producer>(), "ProducerId", "BusinessName");
            productModel.ProductTypes = new SelectList(_context.Set<ProductType>(), "ProductTypeId", "Description");
            productModel.Shelves = new SelectList(_context.Set<Shelf>(), "ShelfId", "Description");
            return View(productModel);

        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProducerId"] = new SelectList(_context.Set<Producer>(), "ProducerId", "Address", product.ProducerId);
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "ProductTypeId", "Description", product.ProductTypeId);
            ViewData["ShelfId"] = new SelectList(_context.Set<Shelf>(), "ShelfId", "Description", product.ShelfId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,ProducerId,ProductTypeId,ShelfId,Quantity,Price,Image,IsOrganic,IsActive,Added")] Product product)
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
            ViewData["ProducerId"] = new SelectList(_context.Set<Producer>(), "ProducerId", "Address", product.ProducerId);
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "ProductTypeId", "Description", product.ProductTypeId);
            ViewData["ShelfId"] = new SelectList(_context.Set<Shelf>(), "ShelfId", "Description", product.ShelfId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Producer)
                .Include(p => p.ProductType)
                .Include(p => p.Shelf)
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
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
