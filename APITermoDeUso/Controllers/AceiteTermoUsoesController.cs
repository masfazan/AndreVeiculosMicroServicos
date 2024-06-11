using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITermoDeUso.Data;
using Models;

namespace APITermoDeUso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AceiteTermoUsoesController : ControllerBase
    {
        private readonly APITermoDeUsoContext _context;

        public AceiteTermoUsoesController(APITermoDeUsoContext context)
        {
            _context = context;
        }

        // GET: api/AceiteTermoUsoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AceiteTermoUso>>> GetAceiteTermoUso()
        {
          if (_context.AceiteTermoUso == null)
          {
              return NotFound();
          }
            return await _context.AceiteTermoUso.ToListAsync();
        }

        // GET: api/AceiteTermoUsoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AceiteTermoUso>> GetAceiteTermoUso(int id)
        {
          if (_context.AceiteTermoUso == null)
          {
              return NotFound();
          }
            var aceiteTermoUso = await _context.AceiteTermoUso.FindAsync(id);

            if (aceiteTermoUso == null)
            {
                return NotFound();
            }

            return aceiteTermoUso;
        }

        // PUT: api/AceiteTermoUsoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAceiteTermoUso(int id, AceiteTermoUso aceiteTermoUso)
        {
            if (id != aceiteTermoUso.Id)
            {
                return BadRequest();
            }

            _context.Entry(aceiteTermoUso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AceiteTermoUsoExists(id))
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

        // POST: api/AceiteTermoUsoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AceiteTermoUso>> PostAceiteTermoUso(AceiteTermoUso aceiteTermoUso)
        {
          if (_context.AceiteTermoUso == null)
          {
              return Problem("Entity set 'APITermoDeUsoContext.AceiteTermoUso'  is null.");
          }
            _context.AceiteTermoUso.Add(aceiteTermoUso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAceiteTermoUso", new { id = aceiteTermoUso.Id }, aceiteTermoUso);
        }

        // DELETE: api/AceiteTermoUsoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAceiteTermoUso(int id)
        {
            if (_context.AceiteTermoUso == null)
            {
                return NotFound();
            }
            var aceiteTermoUso = await _context.AceiteTermoUso.FindAsync(id);
            if (aceiteTermoUso == null)
            {
                return NotFound();
            }

            _context.AceiteTermoUso.Remove(aceiteTermoUso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AceiteTermoUsoExists(int id)
        {
            return (_context.AceiteTermoUso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
