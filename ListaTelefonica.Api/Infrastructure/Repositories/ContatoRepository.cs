using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Infrastructure;
using MongoDB.Driver;

namespace ListaTelefonica.Api.Infrastructure.Repositories
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
            return await _context.Contatos.Find(c => true).ToListAsync();
        }

        public async Task<Contato> GetByIdAsync(string id)
        {
            return await _context.Contatos.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Contato contato)
        {
            await _context.Contatos.InsertOneAsync(contato);
        }

        public async Task UpdateAsync(Contato contato)
        {
            // substitui todo o documento com mesmo Id
            await _context.Contatos.ReplaceOneAsync(c => c.Id == contato.Id, contato);
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Contatos.DeleteOneAsync(c => c.Id == id);
        }
    }
}
