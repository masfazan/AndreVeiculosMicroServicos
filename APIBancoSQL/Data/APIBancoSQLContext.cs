using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIBancoSQL.Data
{
    public class APIBancoSQLContext : DbContext
    {
        public APIBancoSQLContext (DbContextOptions<APIBancoSQLContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Message> Message { get; set; } = default!;
    }
}
