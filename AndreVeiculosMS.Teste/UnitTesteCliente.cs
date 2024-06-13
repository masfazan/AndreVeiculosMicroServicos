using APICliente.Controllers;
using APICliente.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Net;
using System.Reflection;

namespace AndreVeiculosMS.Teste
{
    public class UnitTesteCliente
    {
        
        private DbContextOptions<APIClienteContext> options;


        public void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<APIClienteContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            using (var context = new APIClienteContext(options))
            {
                context.Cliente.Add(new Models.Cliente { atributo = 1, atributo = "", atributo = "" });
                context.SaveChanges();
            }
        }

        [Fact]
        public void TesteGetAll()
        {
            InitializeDataBase();
            using (var context = new APIClienteContext(options))
            {
                ClientesController clientesController = new ClientesController(context);
                IEnumerable<Cliente> clientes = ClientesController.GetCliente().Result.Value;

                Assert.Equal(3, clientes.Count());

            }
        }
        [Fact]
        public void TestGetById()
        {
            InitializeDataBase();
            using (var context = new APIClienteContext(options))
            {
                ClientesController clientesController = new ClientesController(context);
                Cliente clientes = clientesController.GetCliente(2).Result.Value;
                Assert.Equal(2, clientes.atributoChavePrimaria);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new APIClienteContext(options))
            {
                ClientesController controller = new ClientesController(context);
                Cliente address = new Cliente { atributo = 1, atributo = "", atributo = "" };
                Cliente add = controller.PostCliente(address).Result.Value;
                Assert.Equal("", add.atributo);

            }
        }
    }
}
}