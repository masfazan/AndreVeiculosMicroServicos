﻿namespace APIBancoMongo.Utils
{
    public interface IBancoMongoSettings
    {
        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

