using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APICondutor.Data
{
    public class APICondutorContext : DbContext
    {
        public APICondutorContext (DbContextOptions<APICondutorContext> options)
            : base(options)
        {
        }
        
        public DbSet<Models.Condutor> Condutor { get; set; } = default!;

        public DbSet<Models.CNH>? CNH { get; set; }

        public DbSet<Models.Categoria>? Categoria { get; set; }
    }
}
