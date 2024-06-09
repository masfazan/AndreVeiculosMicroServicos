using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIEndereco.Data
{
    public class APIEnderecoContext : DbContext
    {
        public APIEnderecoContext (DbContextOptions<APIEnderecoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Endereco> Endereco { get; set; } = default!;
    }
}
