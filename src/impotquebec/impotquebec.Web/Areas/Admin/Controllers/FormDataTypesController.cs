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
    public class FormDataTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormDataTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FormDataTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormDataTypes.ToListAsync());
        }

        // GET: Admin/FormDataTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDataType = await _context.FormDataTypes
                .FirstOrDefaultAsync(m => m.FormDataTypeId == id);
            if (formDataType == null)
            {
                return NotFound();
            }

            return View(formDataType);
        }

        // GET: Admin/FormDataTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FormDataTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormDataTypeId,Name")] FormDataType formDataType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formDataType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formDataType);
        }

        // GET: Admin/FormDataTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDataType = await _context.FormDataTypes.FindAsync(id);
            if (formDataType == null)
            {
                return NotFound();
            }
            return View(formDataType);
        }

        // POST: Admin/FormDataTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormDataTypeId,Name")] FormDataType formDataType)
        {
            if (id != formDataType.FormDataTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formDataType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormDataTypeExists(formDataType.FormDataTypeId))
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
            return View(formDataType);
        }

        // GET: Admin/FormDataTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDataType = await _context.FormDataTypes
                .FirstOrDefaultAsync(m => m.FormDataTypeId == id);
            if (formDataType == null)
            {
                return NotFound();
            }

            return View(formDataType);
        }

        // POST: Admin/FormDataTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formDataType = await _context.FormDataTypes.FindAsync(id);
            _context.FormDataTypes.Remove(formDataType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormDataTypeExists(int id)
        {
            return _context.FormDataTypes.Any(e => e.FormDataTypeId == id);
        }
    }
}
