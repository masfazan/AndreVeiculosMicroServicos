using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIPagamento.Data
{
    public class APIPagamentoContext : DbContext
    {
        public APIPagamentoContext (DbContextOptions<APIPagamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Boleto> Boleto { get; set; } = default!;

        public DbSet<Models.Cartao>? Cartao { get; set; }

        public DbSet<Models.Pagamento>? Pagamento { get; set; }

        public DbSet<Models.Pix>? Pix { get; set; }

        public DbSet<Models.TipoPix>? TipoPix { get; set; }
    }
}
