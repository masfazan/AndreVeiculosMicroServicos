using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDependente.Data;
using Models;

namespace APIDependente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentesController : ControllerBase
    {
        private readonly APIDependenteContext _context;

        public DependentesController(APIDependenteContext context)
        {
            _context = context;
        }

        // GET: api/Dependentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependente>>> GetDependente()
        {
          if (_context.Dependente == null)
          {
              return NotFound();
          }
            return await _context.Dependente.ToListAsync();
        }

        // GET: api/Dependentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dependente>> GetDependente(string id)
        {
          if (_context.Dependente == null)
          {
              return NotFound();
          }
            var dependente = await _context.Dependente.FindAsync(id);

            if (dependente == null)
            {
                return NotFound();
            }

            return dependente;
        }

        // PUT: api/Dependentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependente(string id, Dependente dependente)
        {
            if (id != dependente.Documento)
            {
                return BadRequest();
            }

            _context.Entry(dependente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependenteExists(id))
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

        // POST: api/Dependentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dependente>> PostDependente(Dependente dependente)
        {
          if (_context.Dependente == null)
          {
              return Problem("Entity set 'APIDependenteContext.Dependente'  is null.");
          }
            _context.Dependente.Add(dependente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DependenteExists(dependente.Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDependente", new { id = dependente.Documento }, dependente);
        }

        // DELETE: api/Dependentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependente(string id)
        {
            if (_context.Dependente == null)
            {
                return NotFound();
            }
            var dependente = await _context.Dependente.FindAsync(id);
            if (dependente == null)
            {
                return NotFound();
            }

            _context.Dependente.Remove(dependente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DependenteExists(string id)
        {
            return (_context.Dependente?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
