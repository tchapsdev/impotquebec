#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using impotquebec.Web.Data;
using impotquebec.Web.Models;

namespace impotquebec.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxFormsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaxFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaxForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxForm>>> GetTaxForms()
        {
            return await _context.TaxForms.ToListAsync();
        }

        // GET: api/TaxForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxForm>> GetTaxForm(int id)
        {
            var taxForm = await _context.TaxForms.FirstOrDefaultAsync(f => f.TaxFormId == id);
            if (taxForm == null)
            {
                return NotFound();
            }
            taxForm.TaxFormSections = await _context.TaxFormSections.Include(s => s.TaxFormLines).Where(s => s.TaxFormId == id).ToListAsync();
            return Ok(taxForm);
        }


        private bool TaxFormExists(int id)
        {
            return _context.TaxForms.Any(e => e.TaxFormId == id);
        }
    }
}
