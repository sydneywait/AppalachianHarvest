﻿using System;
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
using Microsoft.AspNetCore.Hosting;

namespace AppalachianHarvest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        public ProductsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Producer).Include(p => p.ProductType).Include(p => p.Shelf);
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
                .Include(p => p.Producer)
                .Include(p => p.ProductType)
                .Include(p => p.Shelf)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            TimeSpan expirationTime = TimeSpan.FromDays(Convert.ToDouble(product.ProductType.TimeToExpire));
            product.ExpirationDate = product.Added.Add(expirationTime);

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            CreateEditProductViewModel productModel = new CreateEditProductViewModel();


            AddDropdowns(productModel);

            return View(productModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditProductViewModel productModel)
        {


            //if (ModelState.IsValid)
            //{

                if (productModel.Product.ImageUpload!= null)
                {
                    //Store the image in a temp location as it comes back from the uploader
                    using (var memoryStream = new MemoryStream())
                    {
                        await productModel.Product.ImageUpload.CopyToAsync(memoryStream);
                        productModel.Product.Image = memoryStream.ToArray();
                    }

                productModel.Product.Producer = null;
                _context.Add(productModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            //}

            AddDropdowns(productModel);

            return View(productModel);

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

            CreateEditProductViewModel productModel = new CreateEditProductViewModel();
            productModel.Product = product;
            AddDropdowns(productModel);
            return View(productModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateEditProductViewModel productModel)
        {
            if (id != productModel.Product.ProductId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    if (productModel.Product.ImageUpload != null)
                    {
                        //Store the image in a temp location as it comes back from the uploader
                        using (var memoryStream = new MemoryStream())
                        {
                            await productModel.Product.ImageUpload.CopyToAsync(memoryStream);
                            productModel.Product.Image = memoryStream.ToArray();
                        }
                    }
                else
                {
                    var imageFromDatabase = await _context.Products.AsNoTracking()
                   .FirstOrDefaultAsync(a => a.ProductId == id);
                    productModel.Product.Image = imageFromDatabase.Image;
                }

                productModel.Product.Producer = null;
                    _context.Update(productModel.Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productModel.Product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //AddDropdowns(productModel);
            //return View(productModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
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
            var product = await _context.Products.FindAsync(id);
            product.IsActive = false;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public void AddDropdowns(CreateEditProductViewModel productModel)
        {
            productModel.Producers = Add0Dropdown(new SelectList(_context.Set<Producer>(), "ProducerId", "BusinessName"), "producer");
            productModel.ProductTypes = Add0Dropdown(new SelectList(_context.Set<ProductType>(), "ProductTypeId", "Description"), "product type");
            productModel.Shelves = Add0Dropdown(new SelectList(_context.Set<Shelf>(), "ShelfId", "Description"), "product location");
        }
        public static SelectList Add0Dropdown(SelectList selectList, string optionType)
        {

            SelectListItem firstItem = new SelectListItem()
            {
                Text = $"Select a { optionType }"
            };
            List<SelectListItem> newList = selectList.ToList();
            newList.Insert(0, firstItem);

            var selectedItem = newList.FirstOrDefault(item => item.Selected);
            var selectedItemValue = String.Empty;
            if (selectedItem != null)
            {
                selectedItemValue = selectedItem.Value;
            }

            return new SelectList(newList, "Value", "Text", selectedItemValue);
        }
    }
}
