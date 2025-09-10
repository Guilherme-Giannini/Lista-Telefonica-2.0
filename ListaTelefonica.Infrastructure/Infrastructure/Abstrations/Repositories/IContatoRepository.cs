using ListaTelefonica.Domain.Entities;


namespace ListaTelefonica.Application.Abstractions.Repositories
{
    public interface IContatoRepository
    {
        Task<IEnumerable<Contato>> GetAllAsync();
        Task<Contato?> GetByIdAsync(string id);
        Task CreateAsync(Contato contato);
        Task UpdateAsync(Contato contato);
        Task DeleteAsync(string id);
    }
}