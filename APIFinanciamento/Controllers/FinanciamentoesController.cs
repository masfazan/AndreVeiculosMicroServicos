using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFinanciamento.Data;
using Models;

namespace APIFinanciamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciamentoesController : ControllerBase
    {
        private readonly APIFinanciamentoContext _context;

        public FinanciamentoesController(APIFinanciamentoContext context)
        {
            _context = context;
        }

        // GET: api/Financiamentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financiamento>>> GetFinanciamento()
        {
          if (_context.Financiamento == null)
          {
              return NotFound();
          }
            return await _context.Financiamento.ToListAsync();
        }

        // GET: api/Financiamentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financiamento>> GetFinanciamento(int id)
        {
          if (_context.Financiamento == null)
          {
              return NotFound();
          }
            var financiamento = await _context.Financiamento.FindAsync(id);

            if (financiamento == null)
            {
                return NotFound();
            }

            return financiamento;
        }

        // PUT: api/Financiamentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanciamento(int id, Financiamento financiamento)
        {
            if (id != financiamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(financiamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanciamentoExists(id))
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

        // POST: api/Financiamentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Financiamento>> PostFinanciamento(Financiamento financiamento)
        {
          if (_context.Financiamento == null)
          {
              return Problem("Entity set 'APIFinanciamentoContext.Financiamento'  is null.");
          }
            _context.Financiamento.Add(financiamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinanciamento", new { id = financiamento.Id }, financiamento);
        }

        // DELETE: api/Financiamentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanciamento(int id)
        {
            if (_context.Financiamento == null)
            {
                return NotFound();
            }
            var financiamento = await _context.Financiamento.FindAsync(id);
            if (financiamento == null)
            {
                return NotFound();
            }

            _context.Financiamento.Remove(financiamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanciamentoExists(int id)
        {
            return (_context.Financiamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
