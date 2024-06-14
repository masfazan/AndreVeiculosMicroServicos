namespace APIEndereco.Utils
{
    public class EnderecoSettings : IEnderecoSettings
    {
        public string BancoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
