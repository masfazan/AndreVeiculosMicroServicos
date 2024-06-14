using APICarro.Controllers;
using APICarro.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVeiculosMS.Teste
{
    public class UnitTesteCarro
    {
        private DbContextOptions<APICarroContext> options;

        public void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<APICarroContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new APICarroContext(options))
            {
                context.Carro.Add(new Carro { Placa = "12345", Nome = "Augusto", AnoModelo = 2022, AnoFabricacao = 2024, Cor = "branco", Vendido = true });
                context.SaveChanges();
            }
        }

        [Fact]
        public void TesteGetAll()
        {
            InitializeDataBase();

            using (var context = new APICarroContext(options))
            {
                CarroesController carrosController = new CarroesController(context);
                IEnumerable<Carro> carros = carrosController.GetCarro().Result.Value;

                Assert.Equal(1, carros.Count());
            }
        }

        [Fact]
        public void TestGetById()
        {
            InitializeDataBase();

            using (var context = new APICarroContext(options))
            {
                CarroesController carrosController = new CarroesController(context);
                Carro carro = carrosController.GetCarro("2").Result.Value;

                Assert.Equal("2", carro.Placa);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new APICarroContext(options))
            {
                CarroesController controller = new CarroesController(context);
                Carro veiculo = new Carro { Placa = "12345", Nome = "Augusto", AnoModelo = 2022, AnoFabricacao = 2024, Cor = "branco", Vendido = true };
                var result = controller.PostCarro(veiculo).Result;
                Carro add = result.Value;

                Assert.Null(add.Placa);
            }
        }
    }
}
