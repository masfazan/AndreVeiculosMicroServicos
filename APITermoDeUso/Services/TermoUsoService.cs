using APITermoDeUso.Utils;
using Models;
using MongoDB.Driver;

namespace APITermoDeUso.Services
{
    public class TermoUsoService
    {
        private readonly IMongoCollection<TermoDeUso> _termouso;

        public TermoUsoService(ITermoUsoSettings settings)
        {
            var termouso = new MongoClient(settings.ConnectionString);
            var database = termouso.GetDatabase(settings.DatabaseName);
            _termouso = database.GetCollection<TermoDeUso>(settings.BancoCollectionName);
        }

        public List<TermoDeUso> Get() => _termouso.Find(banco => true).ToList();
        public TermoDeUso Get(int Id) => _termouso.Find<TermoDeUso>(termouso => termouso.Id == Id).FirstOrDefault();

        public TermoDeUso Create(TermoDeUso termouso)
        {
            _termouso.InsertOne(termouso);
            return termouso;
        }
    }
}
