using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APITermoDeUso.Data
{
    public class APITermoDeUsoContext : DbContext
    {
        public APITermoDeUsoContext (DbContextOptions<APITermoDeUsoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.TermoDeUso> TermoDeUso { get; set; } = default!;

        public DbSet<Models.AceiteTermoUso>? AceiteTermoUso { get; set; }
    }
}
