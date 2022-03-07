#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tchaps.Impotquebec.Data;
using Tchaps.Impotquebec.Models;

namespace Tchaps.Impotquebec.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaxFormSectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxFormSectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TaxFormSections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaxFormSections.Include(t => t.TaxForm);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/TaxFormSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxFormSection = await _context.TaxFormSections
                .Include(t => t.TaxForm)
                .FirstOrDefaultAsync(m => m.TaxFormSectionId == id);
            if (taxFormSection == null)
            {
                return NotFound();
            }

            return View(taxFormSection);
        }

        // GET: Admin/TaxFormSections/Create
        public IActionResult Create()
        {
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name");
            return View();
        }

        // POST: Admin/TaxFormSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxFormSectionId,TaxFormId,InternalName,LineNumbers,Name,Description,Rank")] TaxFormSection taxFormSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxFormSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name", taxFormSection.TaxFormId);
            return View(taxFormSection);
        }

        // GET: Admin/TaxFormSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxFormSection = await _context.TaxFormSections.FindAsync(id);
            if (taxFormSection == null)
            {
                return NotFound();
            }
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name", taxFormSection.TaxFormId);
            return View(taxFormSection);
        }

        // POST: Admin/TaxFormSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxFormSectionId,TaxFormId,InternalName,LineNumbers,Name,Description,Rank")] TaxFormSection taxFormSection)
        {
            if (id != taxFormSection.TaxFormSectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxFormSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxFormSectionExists(taxFormSection.TaxFormSectionId))
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
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name", taxFormSection.TaxFormId);
            return View(taxFormSection);
        }

        // GET: Admin/TaxFormSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxFormSection = await _context.TaxFormSections
                .Include(t => t.TaxForm)
                .FirstOrDefaultAsync(m => m.TaxFormSectionId == id);
            if (taxFormSection == null)
            {
                return NotFound();
            }

            return View(taxFormSection);
        }

        // POST: Admin/TaxFormSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxFormSection = await _context.TaxFormSections.FindAsync(id);
            _context.TaxFormSections.Remove(taxFormSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxFormSectionExists(int id)
        {
            return _context.TaxFormSections.Any(e => e.TaxFormSectionId == id);
        }
    }
}
