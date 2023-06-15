using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TechLift_HandyMan_Final_Project.Models;
using Topshelf.Runtime;

namespace TechLift_HandyMan_Final_Project.Controllers
{
    public class My_Sub_ServicesController : Controller
    {
        private readonly Final_ProjectContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        
            
        

        public My_Sub_ServicesController(Final_ProjectContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: My_Sub_Services
        public async Task<IActionResult> Index()
        {
              return _context.Sub_Services != null ? 
                          View(await _context.Sub_Services.ToListAsync()) :
                          Problem("Entity set 'Final_ProjectContext.Sub_Services'  is null.");
        }

        // GET: My_Sub_Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sub_Services == null)
            {
                return NotFound();
            }

            var sub_Services = await _context.Sub_Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sub_Services == null)
            {
                return NotFound();
            }

            return View(sub_Services);
        }

        // GET: My_Sub_Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: My_Sub_Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sub_Service_Name,Sub_Service_Descr,Sub_Service_Price,Sub_Service_Image,File")] Sub_Services sub_Services)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(sub_Services.File.FileName);
            string ext = Path.GetExtension(sub_Services.File.FileName);
            sub_Services.Sub_Service_Image = filename = filename + DateTime.Now.ToString("yymmssfff") + ext;
            string path = Path.Combine(wwwRootPath + "/Images/", filename);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await sub_Services.File.CopyToAsync(filestream);
            }

            _context.Add(sub_Services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: My_Sub_Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sub_Services == null)
            {
                return NotFound();
            }

            var sub_Services = await _context.Sub_Services.FindAsync(id);
            if (sub_Services == null)
            {
                return NotFound();
            }
            return View(sub_Services);
        }

        // POST: My_Sub_Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sub_Service_Name,Sub_Service_Descr,Sub_Service_Price,Sub_Service_Image")] Sub_Services sub_Services)
        {
            if (id != sub_Services.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sub_Services);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sub_ServicesExists(sub_Services.Id))
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
            return View(sub_Services);
        }

        // GET: My_Sub_Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sub_Services == null)
            {
                return NotFound();
            }

            var sub_Services = await _context.Sub_Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sub_Services == null)
            {
                return NotFound();
            }

            return View(sub_Services);
        }

        // POST: My_Sub_Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sub_Services == null)
            {
                return Problem("Entity set 'Final_ProjectContext.Sub_Services'  is null.");
            }
            var sub_Services = await _context.Sub_Services.FindAsync(id);
            if (sub_Services != null)
            {
                _context.Sub_Services.Remove(sub_Services);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sub_ServicesExists(int id)
        {
          return (_context.Sub_Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
