namespace APIBancoMongo.Utils
{
    public interface IBancoMongoSettings
    {
        public string BankCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

