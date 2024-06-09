using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPagamento.Data;
using Models;

namespace APIPagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPixesController : ControllerBase
    {
        private readonly APIPagamentoContext _context;

        public TipoPixesController(APIPagamentoContext context)
        {
            _context = context;
        }

        // GET: api/TipoPixes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPix>>> GetTipoPix()
        {
          if (_context.TipoPix == null)
          {
              return NotFound();
          }
            return await _context.TipoPix.ToListAsync();
        }

        // GET: api/TipoPixes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPix>> GetTipoPix(int id)
        {
          if (_context.TipoPix == null)
          {
              return NotFound();
          }
            var tipoPix = await _context.TipoPix.FindAsync(id);

            if (tipoPix == null)
            {
                return NotFound();
            }

            return tipoPix;
        }

        // PUT: api/TipoPixes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPix(int id, TipoPix tipoPix)
        {
            if (id != tipoPix.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPixExists(id))
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

        // POST: api/TipoPixes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPix>> PostTipoPix(TipoPix tipoPix)
        {
          if (_context.TipoPix == null)
          {
              return Problem("Entity set 'APIPagamentoContext.TipoPix'  is null.");
          }
            _context.TipoPix.Add(tipoPix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPix", new { id = tipoPix.Id }, tipoPix);
        }

        // DELETE: api/TipoPixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPix(int id)
        {
            if (_context.TipoPix == null)
            {
                return NotFound();
            }
            var tipoPix = await _context.TipoPix.FindAsync(id);
            if (tipoPix == null)
            {
                return NotFound();
            }

            _context.TipoPix.Remove(tipoPix);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPixExists(int id)
        {
            return (_context.TipoPix?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
