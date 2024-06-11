using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIFinanciamento.Data
{
    public class APIFinanciamentoContext : DbContext
    {
        public APIFinanciamentoContext (DbContextOptions<APIFinanciamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Financiamento> Financiamento { get; set; } = default!;
    }
}
