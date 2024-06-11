using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIValidacaoPendenciaFinanceira.Data
{
    public class APIValidacaoPendenciaFinanceiraContext : DbContext
    {
        public APIValidacaoPendenciaFinanceiraContext (DbContextOptions<APIValidacaoPendenciaFinanceiraContext> options)
            : base(options)
        {
        }

        public DbSet<Models.PendenciaFinanceira> PendenciaFinanceira { get; set; } = default!;
    }
}
