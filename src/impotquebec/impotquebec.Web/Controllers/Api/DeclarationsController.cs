#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tchaps.Impotquebec.Data;
using Tchaps.Impotquebec.Helpers;
using Tchaps.Impotquebec.Models;

namespace Tchaps.Impotquebec.Controllers.Api
{
    [Route("api/[controller]")]
   // [Produces("application/json")]
    [ApiController]
    public class DeclarationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeclarationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Declarations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Declaration>>> GetDeclarations()
        {
            return await _context.Declarations.ToListAsync();
        }

        // GET: api/Declarations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Declaration>> GetDeclaration(int id)
        {
            var declaration = await _context.Declarations.FindAsync(id);

            if (declaration == null)
            {
                return NotFound();
            }

            return declaration;
        }

        // PUT: api/Declarations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<IActionResult> PostDeclaration(int id, [FromBody]Declaration declaration)
        {
            //if (id != declaration.DeclarationId)
            //{
            //    return BadRequest();
            //}

            TaxProcessor.ProcessTp1Lines(declaration);

            try
            {
                if (declaration.DeclarationId == 0)
                {
                    declaration.Created = DateTime.UtcNow;
                    declaration.Modified = DateTime.UtcNow;
                    _context.Declarations.Add(declaration);
                }
                else
                {
                    var model = _context.Declarations.FindAsync(declaration.DeclarationId);

                }

                await _context.SaveChangesAsync();
                return Ok(declaration.DeclarationId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeclarationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/Declarations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Declaration>> PostDeclaration(Declaration declaration)
        //{
        //    _context.Declarations.Add(declaration);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDeclaration", new { id = declaration.DeclarationId }, declaration);
        //}

        //// DELETE: api/Declarations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDeclaration(int id)
        //{
        //    var declaration = await _context.Declarations.FindAsync(id);
        //    if (declaration == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Declarations.Remove(declaration);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool DeclarationExists(int id)
        {
            return _context.Declarations.Any(e => e.DeclarationId == id);
        }
    }
}
