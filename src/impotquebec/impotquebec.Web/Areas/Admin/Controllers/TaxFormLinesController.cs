#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using impotquebec.Web.Data;
using impotquebec.Web.Models;

namespace impotquebec.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaxFormLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxFormLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TaxFormLines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaxFormLines.Include(t => t.TaxForm).Include(t => t.TaxFormSection);
            return View(await applicationDbContext.OrderByDescending(l => l.TaxFormLineId).ToListAsync());
        }

        // GET: Admin/TaxFormLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxFormLine = await _context.TaxFormLines
                .Include(t => t.TaxForm)
                .Include(t => t.TaxFormSection)
                .FirstOrDefaultAsync(m => m.TaxFormLineId == id);
            if (taxFormLine == null)
            {
                return NotFound();
            }

            return View(taxFormLine);
        }

        // GET: Admin/TaxFormLines/Create
        public IActionResult Create()
        {
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name");
            ViewData["TaxFormSectionId"] = new SelectList(_context.TaxFormSections, "TaxFormSectionId", "Name");
            return View(new TaxFormLine { TaxFormId=1, TaxFormSectionId=6, Description="."});
        }

        // POST: Admin/TaxFormLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxFormLineId,TaxFormId,LineNumber,Rank,IsActive,IsReadOnly,TaxFormSectionId,Name,Description")] TaxFormLine taxFormLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxFormLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name", taxFormLine.TaxFormId);
            ViewData["TaxFormSectionId"] = new SelectList(_context.TaxFormSections, "TaxFormSectionId", "Name", taxFormLine.TaxFormSectionId);
            return View(taxFormLine);
        }

        // GET: Admin/TaxFormLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxFormLine = await _context.TaxFormLines.FindAsync(id);
            if (taxFormLine == null)
            {
                return NotFound();
            }
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name", taxFormLine.TaxFormId);
            ViewData["TaxFormSectionId"] = new SelectList(_context.TaxFormSections, "TaxFormSectionId", "Name", taxFormLine.TaxFormSectionId);
            return View(taxFormLine);
        }

        // POST: Admin/TaxFormLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxFormLineId,TaxFormId,LineNumber,Rank,IsActive,IsReadOnly,TaxFormSectionId,Name,Description")] TaxFormLine taxFormLine)
        {
            if (id != taxFormLine.TaxFormLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxFormLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxFormLineExists(taxFormLine.TaxFormLineId))
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
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "Name", taxFormLine.TaxFormId);
            ViewData["TaxFormSectionId"] = new SelectList(_context.TaxFormSections, "TaxFormSectionId", "Name", taxFormLine.TaxFormSectionId);
            return View(taxFormLine);
        }

        // GET: Admin/TaxFormLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxFormLine = await _context.TaxFormLines
                .Include(t => t.TaxForm)
                .Include(t => t.TaxFormSection)
                .FirstOrDefaultAsync(m => m.TaxFormLineId == id);
            if (taxFormLine == null)
            {
                return NotFound();
            }

            return View(taxFormLine);
        }

        // POST: Admin/TaxFormLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxFormLine = await _context.TaxFormLines.FindAsync(id);
            _context.TaxFormLines.Remove(taxFormLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxFormLineExists(int id)
        {
            return _context.TaxFormLines.Any(e => e.TaxFormLineId == id);
        }
    }
}
