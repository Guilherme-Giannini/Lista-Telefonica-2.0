using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Api.Domain;

namespace ListaTelefonica.Api.Infrastructure.Repositories
{
    public interface IContatoRepository
    {
        Task<Contato> GetByIdAsync(string id);
        Task<IEnumerable<Contato>> GetAllAsync();
        Task CreateAsync(Contato contato);
        Task UpdateAsync(Contato contato);
        Task DeleteAsync(string id);
    }
}