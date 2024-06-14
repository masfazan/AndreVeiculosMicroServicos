using static APIBancoMongo.Utils.BancoMongoSettings;

namespace APIBancoMongo.Utils
{
    public class BancoMongoSettings
    {

        public string BankCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
