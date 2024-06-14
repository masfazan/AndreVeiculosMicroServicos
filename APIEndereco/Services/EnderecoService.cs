using Models;

namespace APIEndereco.Services
{
    public class EnderecoService
    {
        private readonly IMongoCollection<Banco> _banco;

        public BancoService(IBancoSettings settings)
        {
            var banco = new MongoClient(settings.ConnectionString);
            var database = banco.GetDatabase(settings.DatabaseName);
            _banco = database.GetCollection<Banco>(settings.BancoCollectionName);
        }

        public List<Banco> Get() => _banco.Find(banco => true).ToList();
        public Banco Get(string Cnpj) => _banco.Find<Banco>(banco => banco.Cnpj == Cnpj).FirstOrDefault();

        public Banco Create(Banco banco)
        {
            _banco.InsertOne(banco);
            return banco;
        }
    }
}
