using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIBancoMongo.Data
{
    public class APIBancoMongoContext : DbContext
    {
        public APIBancoMongoContext (DbContextOptions<APIBancoMongoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Message> Message { get; set; } = default!;
    }
}
