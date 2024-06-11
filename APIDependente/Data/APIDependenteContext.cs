using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIDependente.Data
{
    public class APIDependenteContext : DbContext
    {
        public APIDependenteContext (DbContextOptions<APIDependenteContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Dependente> Dependente { get; set; } = default!;
    }
}
