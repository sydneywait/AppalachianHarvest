using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppalachianHarvest.Data;
using AppalachianHarvest.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using AppalachianHarvest.Models.ViewModels;
using AppalachianHarvest.Models.SubModels;


namespace AppalachianHarvest.Controllers
{
    public class ProducersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _context2;

        private readonly IHostingEnvironment _hostingEnvironment;


        public ProducersController(ApplicationDbContext context, ApplicationDbContext context2, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _context2 = context2;

            _hostingEnvironment = hostingEnvironment;

        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producers.ToListAsync());
        }

        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .Include(p=>p.Products)
                .ThenInclude(pr=>pr.ProductType)
                .FirstOrDefaultAsync(m => m.ProducerId == id);
            if (producer == null)
            {
                return NotFound();
            }
            foreach (Product product in producer.Products)
            {
                TimeSpan expirationTime = TimeSpan.FromDays(Convert.ToDouble(product.ProductType.TimeToExpire));
                product.ExpirationDate = product.Added.Add(expirationTime);
            }

            return View(producer);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProducerId,FirstName,LastName,BusinessName,Phone,Email,Address,City,State,ZipCode,ImageUpload,IsActive")] Producer producer)
        {
            if (ModelState.IsValid)
            {

                if (producer.ImageUpload != null)
                {
                    //Store the image in a temp location as it comes back from the uploader
                    using (var memoryStream = new MemoryStream())
                    {
                        await producer.ImageUpload.CopyToAsync(memoryStream);
                        producer.ProducerImage = memoryStream.ToArray();
                    }
                }
                producer.IsActive = true;
                _context.Add(producer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            EditProducerViewModel producerModel = new EditProducerViewModel();
            producerModel.Producer = producer;
            return View(producerModel);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProducerViewModel producerModel)
        {

            
            if (id != producerModel.Producer.ProducerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (producerModel.Producer.ImageUpload != null)
                    {
                        //Store the image in a temp location as it comes back from the uploader
                        using (var memoryStream = new MemoryStream())
                        {
                            await producerModel.Producer.ImageUpload.CopyToAsync(memoryStream);
                            producerModel.Producer.ProducerImage = memoryStream.ToArray();
                        }
                    }
                 
                    _context.Update(producerModel.Producer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerExists(producerModel.Producer.ProducerId))
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
            return View(producerModel.Producer);
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .FirstOrDefaultAsync(m => m.ProducerId == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            producer.IsActive = false;
            _context.Producers.Update(producer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerExists(int id)
        {
            return _context.Producers.Any(e => e.ProducerId == id);
        }

        // GET: Producers/Reports
        public async Task<IActionResult> Reports(ProducerReportViewModel report)
        {

            report.Producers = Add0Dropdown(new SelectList(_context.Set<Producer>(), "ProducerId", "BusinessName"), "producer");
            report.ProductTypes = Add0Dropdown(new SelectList(_context.Set<ProductType>(), "ProductTypeId", "Description"), "product type");


            var OrderProducts = await _context.OrderProduct
                .Include(op=>op.Product)
                .ThenInclude(p=>p.ProductType)
                .Include(op=>op.Order)
                .ToListAsync();


            if(report.selectedProducer != null) {

                var ProductsThisProducer = await _context.Products.Where(p => p.ProducerId == report.selectedProducer.ProducerId).ToListAsync();
                var PTheseDates = ProductsThisProducer.Where(p => p.Added <= report.EndDate && p.Added >= report.StartDate);

                var OPThisProducer = OrderProducts.Where(op => op.Product.ProducerId == report.selectedProducer.ProducerId);
                var OPTheseDates = OPThisProducer.Where(op => op.Order.OrderDate <= report.EndDate && op.Order.OrderDate >= report.StartDate);


                //ICollection<ProductReport> soldProducts = new ICollection<ProductReport>();

                foreach (OrderProduct op in OPTheseDates)
                  {
                     
                    if(report.soldProducts!= null && report.soldProducts.Any(pr => pr.Product.ProductId == op.ProductId))
                    {
                        ProductReport thisProductReport = report.soldProducts
                            .FirstOrDefault(pr => pr.Product.ProductId == op.ProductId);
                        report.soldProducts.Remove(thisProductReport);
                        thisProductReport.Sold += 1;

                        //Calculate the time to expire for this product
                        TimeSpan expirationTime = TimeSpan.FromDays(Convert.ToDouble(thisProductReport.Product.ProductType.TimeToExpire));

                        thisProductReport.Product.ExpirationDate = thisProductReport.Product.Added.Add(expirationTime);

                        if (thisProductReport.Product.ExpirationDate < report.EndDate)
                        {
                            //TODO if expiration date has passed, add expiration quantity
                            thisProductReport.Expired = thisProductReport.Product.Quantity - thisProductReport.Sold;
                        }
                        else
                        {
                            thisProductReport.Expired = 0;
                        }
                        report.soldProducts.Add(thisProductReport);
                        var count = report.soldProducts.Count();
                        
                    }
                    else
                    {
                        ProductReport ProductReport = new ProductReport();
                        ProductReport.Product = op.Product;
                        ProductReport.Sold = 1;
                        report.soldProducts.Add(ProductReport);
                    }
                    
                    report.TotalSales += op.Product.Price;
                
                    
            }

            foreach(Product p in PTheseDates)
            {


            }

            

                
                

            }


            return View(report);
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
