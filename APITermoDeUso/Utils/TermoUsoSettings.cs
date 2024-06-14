namespace APITermoDeUso.Utils
{
    public class TermoUsoSettings : ITermoUsoSettings
    {
        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
