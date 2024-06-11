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
    public class TermoDeUsoesController : ControllerBase
    {
        private readonly APITermoDeUsoContext _context;

        public TermoDeUsoesController(APITermoDeUsoContext context)
        {
            _context = context;
        }

        // GET: api/TermoDeUsoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TermoDeUso>>> GetTermoDeUso()
        {
          if (_context.TermoDeUso == null)
          {
              return NotFound();
          }
            return await _context.TermoDeUso.ToListAsync();
        }

        // GET: api/TermoDeUsoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TermoDeUso>> GetTermoDeUso(int id)
        {
          if (_context.TermoDeUso == null)
          {
              return NotFound();
          }
            var termoDeUso = await _context.TermoDeUso.FindAsync(id);

            if (termoDeUso == null)
            {
                return NotFound();
            }

            return termoDeUso;
        }

        // PUT: api/TermoDeUsoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTermoDeUso(int id, TermoDeUso termoDeUso)
        {
            if (id != termoDeUso.Id)
            {
                return BadRequest();
            }

            _context.Entry(termoDeUso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermoDeUsoExists(id))
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

        // POST: api/TermoDeUsoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TermoDeUso>> PostTermoDeUso(TermoDeUso termoDeUso)
        {
          if (_context.TermoDeUso == null)
          {
              return Problem("Entity set 'APITermoDeUsoContext.TermoDeUso'  is null.");
          }
            _context.TermoDeUso.Add(termoDeUso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTermoDeUso", new { id = termoDeUso.Id }, termoDeUso);
        }

        // DELETE: api/TermoDeUsoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTermoDeUso(int id)
        {
            if (_context.TermoDeUso == null)
            {
                return NotFound();
            }
            var termoDeUso = await _context.TermoDeUso.FindAsync(id);
            if (termoDeUso == null)
            {
                return NotFound();
            }

            _context.TermoDeUso.Remove(termoDeUso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TermoDeUsoExists(int id)
        {
            return (_context.TermoDeUso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
