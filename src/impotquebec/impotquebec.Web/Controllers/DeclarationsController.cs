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
using Microsoft.AspNetCore.Authorization;
using Tchaps.Impotquebec.Helpers;

namespace Tchaps.Impotquebec.Controllers
{
    public class DeclarationsController : SecureBaseController
    {
        public DeclarationsController(ApplicationDbContext context):base(context)
        {
        }

        // GET: Declarations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Declarations
                                                .Include(d => d.TaxForm)
                                                .Include(d => d.User);
            return View(await applicationDbContext.OrderByDescending(d => d.DeclarationId).ToListAsync());
        }

        // GET: Declarations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations
                .Include(d => d.TaxForm)
                .Include(d => d.User)
                .Include(d => d.Details)
                .FirstOrDefaultAsync(m => m.DeclarationId == id);
            
           // TaxProcessor.ProcessTp1Lines(declaration);

            if (declaration == null)
            {
                return NotFound();
            }

            return View(declaration);
        }

        // GET: Declarations/Create
        public async Task<IActionResult> Create(string code)
        {
            var taxForm = await _context.TaxForms
               .FirstOrDefaultAsync(m => m.Code == code);
            
            if (taxForm == null)
            {
                return NotFound();
            }

            return View(new Declaration
            {
                TaxFormId = taxForm.TaxFormId,
                TaxForm = taxForm,
                User = CurrentUser,
                UserId = CurrentUser.Id,
                FiscalYear = (short)DateTime.Now.Year
            });
        }

        // POST: Declarations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeclarationId,FiscalYear,TotalIncome,TotalDeductions,NetIncome,TaxableIncome,NonRefundableTaxCredits,IncomeTaxAndContributions,Refund,BalanceDue,TaxFormId,UserId,History,Created,Modified")] Declaration declaration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(declaration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "TaxFormId", declaration.TaxFormId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", declaration.UserId);
            return View(declaration);
        }

        // GET: Declarations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations.FindAsync(id);
            if (declaration == null)
            {
                return NotFound();
            }
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "TaxFormId", declaration.TaxFormId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", declaration.UserId);
            return View(declaration);
        }

        // POST: Declarations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeclarationId,FiscalYear,TotalIncome,TotalDeductions,NetIncome,TaxableIncome,NonRefundableTaxCredits,IncomeTaxAndContributions,Refund,BalanceDue,TaxFormId,UserId,History,Created,Modified")] Declaration declaration)
        {
            if (id != declaration.DeclarationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(declaration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeclarationExists(declaration.DeclarationId))
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
            ViewData["TaxFormId"] = new SelectList(_context.TaxForms, "TaxFormId", "TaxFormId", declaration.TaxFormId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", declaration.UserId);
            return View(declaration);
        }

        // GET: Declarations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var declaration = await _context.Declarations
                .Include(d => d.TaxForm)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DeclarationId == id);
            if (declaration == null)
            {
                return NotFound();
            }

            return View(declaration);
        }

        // POST: Declarations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var declaration = await _context.Declarations.FindAsync(id);
            _context.Declarations.Remove(declaration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeclarationExists(int id)
        {
            return _context.Declarations.Any(e => e.DeclarationId == id);
        }
    }
}
