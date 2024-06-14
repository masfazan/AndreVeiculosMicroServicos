using APIBanco.Utils;
using APIBancoMongo.Utils;
using Models;
using MongoDB.Driver;

namespace APIBancoMongo.Services
{
    public class BancoMongoServices
    {
        private readonly IMongoCollection<Banco> _bancomongo;

        public BancoMongoServices(IBancoMongoSettings settings)
        {
            var banco = new MongoClient(settings.ConnectionString);
            var database = banco.GetDatabase(settings.DatabaseName);
            _bancomongo = database.GetCollection<Banco>(settings.BancoCollectionName);
        }

        public List<Banco> Get() => _bancomongo.Find(banco => true).ToList();
        public Banco Get(string Cnpj) => _bancomongo.Find<Banco>(bancomongo => bancomongo.Cnpj == Cnpj).FirstOrDefault();

        public Banco Create(Banco bancomongo)
        {
            _bancomongo.InsertOne(bancomongo);
            return bancomongo;
        }
    }
}

