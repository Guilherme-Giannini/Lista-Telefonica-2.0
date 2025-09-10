using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ListaTelefonica.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<MongoContato> Contatos => 
            _database.GetCollection<MongoContato>("Contatos");
    }
}