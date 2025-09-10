using ListaTelefonica.Application.Abstractions.Repositories; // IContatoRepository
using ListaTelefonica.Domain.Entities; // Contato
using ListaTelefonica.Infrastructure.Persistence; // MongoContato, MongoDbContext
using MongoDB.Driver;

namespace ListaTelefonica.Infrastructure.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly MongoDbContext _context;

        public ContatoRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            var contatos = await _context.Contatos.Find(c => true).ToListAsync();
            return contatos.Select(MapToDomain).ToList(); // Garante List<Contato>
        }

        public async Task<Contato?> GetByIdAsync(string id)
        {
            var mongoContato = await _context.Contatos.Find(c => c.Id == id).FirstOrDefaultAsync();
            return mongoContato is null ? null : MapToDomain(mongoContato);
        }

        public async Task CreateAsync(Contato contato)
        {
            var mongoContato = MapToMongo(contato);
            await _context.Contatos.InsertOneAsync(mongoContato);
            contato.Id = mongoContato.Id;
        }

        public async Task UpdateAsync(Contato contato)
        {
            var mongoContato = MapToMongo(contato);
            var result = await _context.Contatos.ReplaceOneAsync(
                c => c.Id == contato.Id,
                mongoContato
            );

            if (result.ModifiedCount == 0)
            {
                throw new Exception("Nenhum contato atualizado. Verifique se o Id está correto.");
            }
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Contatos.DeleteOneAsync(c => c.Id == id);
        }

        private static Contato MapToDomain(MongoContato mongo) =>
            new Contato
            {
                Id = mongo.Id,
                Nome = mongo.Nome,
                Telefone = mongo.Telefone,
                Email = mongo.Email,
                DataNascimento = mongo.DataNascimento,
                Enderecos = mongo.Enderecos?.ToList() ?? new List<string>() // evita null
            };

        private static MongoContato MapToMongo(Contato contato) =>
            new MongoContato
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Telefone = contato.Telefone,
                Email = contato.Email,
                DataNascimento = contato.DataNascimento,
                Enderecos = contato.Enderecos?.ToList() ?? new List<string>()
            };
    }
}