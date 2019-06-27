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
            return View(await _context.Producer.ToListAsync());
        }

        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _context.Producer
                .FirstOrDefaultAsync(m => m.ProducerId == id);
            if (producer == null)
            {
                return NotFound();
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

            var producer = await _context.Producer.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProducerId,FirstName,LastName,BusinessName,Phone,Email,Address,City,State,ZipCode,ImageUpload,IsActive")]Producer producer)
        {

            
            if (id != producer.ProducerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
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
                    else
                    {
                        var p = await _context2.Producer.FindAsync(id);
                        producer.ProducerImage = p.ProducerImage;
                    }
                    _context.Update(producer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerExists(producer.ProducerId))
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
            return View(producer);
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _context.Producer
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
            var producer = await _context.Producer.FindAsync(id);
            producer.IsActive = false;
            _context.Producer.Update(producer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerExists(int id)
        {
            return _context.Producer.Any(e => e.ProducerId == id);
        }
    }
}
