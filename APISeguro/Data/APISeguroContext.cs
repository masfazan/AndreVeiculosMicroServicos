using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APISeguro.Data
{
    public class APISeguroContext : DbContext
    {
        public APISeguroContext (DbContextOptions<APISeguroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Seguro> Seguro { get; set; } = default!;
    }
}
