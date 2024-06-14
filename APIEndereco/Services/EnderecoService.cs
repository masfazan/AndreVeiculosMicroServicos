using APIEndereco.Utils;
using Models;
using MongoDB.Driver;

namespace APIEndereco.Services
{
    public class EnderecoService
    {
        private readonly IMongoCollection<Endereco> _endereco;

        public EnderecoService(IEnderecoSettings settings)
        {
            var endereco = new MongoClient(settings.ConnectionString);
            var database = endereco.GetDatabase(settings.DatabaseName);
            _endereco = database.GetCollection<Endereco>(settings.BancoCollectionName);
        }

        public List<Endereco> Get() => _endereco.Find(endereco => true).ToList();
        public Endereco Get(int Id) => _endereco.Find<Endereco>(endereco => endereco.Id == Id).FirstOrDefault();

        public Endereco Create(Endereco endereco)
        {
            _endereco.InsertOne(endereco);
            return endereco;
        }
    }
}
