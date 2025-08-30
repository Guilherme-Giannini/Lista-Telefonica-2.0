using ListaTelefonica.Api.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ListaTelefonica.Api.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Coleção de Contatos
        public IMongoCollection<Contato> Contatos =>
            _database.GetCollection<Contato>("Contatos");
    }
}