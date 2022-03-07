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
    public class TaxFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TaxForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxForms.ToListAsync());
        }

        // GET: Admin/TaxForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxForm = await _context.TaxForms
                .FirstOrDefaultAsync(m => m.TaxFormId == id);
            if (taxForm == null)
            {
                return NotFound();
            }

            return View(taxForm);
        }

        // GET: Admin/TaxForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaxForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxFormId,Code,Name,Description")] TaxForm taxForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxForm);
        }

        // GET: Admin/TaxForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxForm = await _context.TaxForms.FindAsync(id);
            if (taxForm == null)
            {
                return NotFound();
            }
            return View(taxForm);
        }

        // POST: Admin/TaxForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxFormId,Code,Name,Description")] TaxForm taxForm)
        {
            if (id != taxForm.TaxFormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxFormExists(taxForm.TaxFormId))
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
            return View(taxForm);
        }

        // GET: Admin/TaxForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxForm = await _context.TaxForms
                .FirstOrDefaultAsync(m => m.TaxFormId == id);
            if (taxForm == null)
            {
                return NotFound();
            }

            return View(taxForm);
        }

        // POST: Admin/TaxForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxForm = await _context.TaxForms.FindAsync(id);
            _context.TaxForms.Remove(taxForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxFormExists(int id)
        {
            return _context.TaxForms.Any(e => e.TaxFormId == id);
        }
    }
}
