namespace APITermoDeUso.Utils
{
    public interface ITermoUsoSettings
    {
        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
