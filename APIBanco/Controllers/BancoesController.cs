using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBanco.Data;
using Models;

namespace APIBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoesController : ControllerBase
    {
        private readonly APIBancoContext _context;

        public BancoesController(APIBancoContext context)
        {
            _context = context;
        }


        // GET: api/Bancoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBanco()
        {
          if (_context.Banco == null)
          {
              return NotFound();
          }
            return await _context.Banco.ToListAsync();
        }

        // GET: api/Bancoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banco>> GetBanco(string id)
        {
          if (_context.Banco == null)
          {
              return NotFound();
          }
            var banco = await _context.Banco.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return banco;
        }

        // PUT: api/Bancoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanco(string id, Banco banco)
        {
            if (id != banco.Cnpj)
            {
                return BadRequest();
            }

            _context.Entry(banco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoExists(id))
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

        // POST: api/Bancoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
          if (_context.Banco == null)
          {
              return Problem("Entity set 'APIBancoContext.Banco'  is null.");
          }
            _context.Banco.Add(banco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BancoExists(banco.Cnpj))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBanco", new { id = banco.Cnpj }, banco);
        }

        // DELETE: api/Bancoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanco(string id)
        {
            if (_context.Banco == null)
            {
                return NotFound();
            }
            var banco = await _context.Banco.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }

            _context.Banco.Remove(banco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BancoExists(string id)
        {
            return (_context.Banco?.Any(e => e.Cnpj == id)).GetValueOrDefault();
        }
    }
}
