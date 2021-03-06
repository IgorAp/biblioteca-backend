namespace BibliotecaBackend.Infra.Data.ReadModel
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CollectionName { get; set; } = null!;
    }
}
