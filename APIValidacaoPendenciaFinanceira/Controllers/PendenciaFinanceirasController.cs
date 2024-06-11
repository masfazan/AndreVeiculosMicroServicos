using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIValidacaoPendenciaFinanceira.Data;
using Models;

namespace APIValidacaoPendenciaFinanceira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendenciaFinanceirasController : ControllerBase
    {
        private readonly APIValidacaoPendenciaFinanceiraContext _context;

        public PendenciaFinanceirasController(APIValidacaoPendenciaFinanceiraContext context)
        {
            _context = context;
        }

        // GET: api/PendenciaFinanceiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PendenciaFinanceira>>> GetPendenciaFinanceira()
        {
          if (_context.PendenciaFinanceira == null)
          {
              return NotFound();
          }
            return await _context.PendenciaFinanceira.ToListAsync();
        }

        // GET: api/PendenciaFinanceiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PendenciaFinanceira>> GetPendenciaFinanceira(int id)
        {
          if (_context.PendenciaFinanceira == null)
          {
              return NotFound();
          }
            var pendenciaFinanceira = await _context.PendenciaFinanceira.FindAsync(id);

            if (pendenciaFinanceira == null)
            {
                return NotFound();
            }

            return pendenciaFinanceira;
        }

        // PUT: api/PendenciaFinanceiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPendenciaFinanceira(int id, PendenciaFinanceira pendenciaFinanceira)
        {
            if (id != pendenciaFinanceira.Id)
            {
                return BadRequest();
            }

            _context.Entry(pendenciaFinanceira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendenciaFinanceiraExists(id))
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

        // POST: api/PendenciaFinanceiras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PendenciaFinanceira>> PostPendenciaFinanceira(PendenciaFinanceira pendenciaFinanceira)
        {
          if (_context.PendenciaFinanceira == null)
          {
              return Problem("Entity set 'APIValidacaoPendenciaFinanceiraContext.PendenciaFinanceira'  is null.");
          }
            _context.PendenciaFinanceira.Add(pendenciaFinanceira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPendenciaFinanceira", new { id = pendenciaFinanceira.Id }, pendenciaFinanceira);
        }

        // DELETE: api/PendenciaFinanceiras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePendenciaFinanceira(int id)
        {
            if (_context.PendenciaFinanceira == null)
            {
                return NotFound();
            }
            var pendenciaFinanceira = await _context.PendenciaFinanceira.FindAsync(id);
            if (pendenciaFinanceira == null)
            {
                return NotFound();
            }

            _context.PendenciaFinanceira.Remove(pendenciaFinanceira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PendenciaFinanceiraExists(int id)
        {
            return (_context.PendenciaFinanceira?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
