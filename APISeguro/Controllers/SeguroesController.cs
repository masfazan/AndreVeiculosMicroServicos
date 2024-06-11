using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISeguro.Data;
using Models;

namespace APISeguro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroesController : ControllerBase
    {
        private readonly APISeguroContext _context;

        public SeguroesController(APISeguroContext context)
        {
            _context = context;
        }

        // GET: api/Seguroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguro>>> GetSeguro()
        {
          if (_context.Seguro == null)
          {
              return NotFound();
          }
            return await _context.Seguro.ToListAsync();
        }

        // GET: api/Seguroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seguro>> GetSeguro(int id)
        {
          if (_context.Seguro == null)
          {
              return NotFound();
          }
            var seguro = await _context.Seguro.FindAsync(id);

            if (seguro == null)
            {
                return NotFound();
            }

            return seguro;
        }

        // PUT: api/Seguroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguro(int id, Seguro seguro)
        {
            if (id != seguro.Id)
            {
                return BadRequest();
            }

            _context.Entry(seguro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroExists(id))
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

        // POST: api/Seguroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seguro>> PostSeguro(Seguro seguro)
        {
          if (_context.Seguro == null)
          {
              return Problem("Entity set 'APISeguroContext.Seguro'  is null.");
          }
            _context.Seguro.Add(seguro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguro", new { id = seguro.Id }, seguro);
        }

        // DELETE: api/Seguroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguro(int id)
        {
            if (_context.Seguro == null)
            {
                return NotFound();
            }
            var seguro = await _context.Seguro.FindAsync(id);
            if (seguro == null)
            {
                return NotFound();
            }

            _context.Seguro.Remove(seguro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeguroExists(int id)
        {
            return (_context.Seguro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
