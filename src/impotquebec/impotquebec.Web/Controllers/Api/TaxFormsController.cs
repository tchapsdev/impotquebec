#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tchaps.Impotquebec.Data;
using Tchaps.Impotquebec.Models;

namespace Tchaps.Impotquebec.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxFormsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TaxFormsController> _logger;

        public TaxFormsController(ApplicationDbContext context, ILogger<TaxFormsController> logger)
        {
            _context = context;
            _logger = logger;
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
            taxForm.TaxFormSections = await _context.TaxFormSections.Include(s => s.TaxFormLines)
                .ThenInclude(s => s.FormDataType)
                .Where(s => s.TaxFormId == id)
                .OrderBy(s => s.Rank)
                .ToListAsync();
            return Ok(taxForm);
        }


        private bool TaxFormExists(int id)
        {
            return _context.TaxForms.Any(e => e.TaxFormId == id);
        }
    }
}
