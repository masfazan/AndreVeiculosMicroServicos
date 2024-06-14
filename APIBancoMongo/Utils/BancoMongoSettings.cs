using APIBanco.Utils;
using static APIBancoMongo.Utils.BancoMongoSettings;

namespace APIBancoMongo.Utils
{
    public class BancoMongoSettings : IBancoMongoSettings
    {

        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
