using MediatR;
using ListaTelefonica.Application.Abstractions.Repositories; // IContatoRepository
using ListaTelefonica.Domain.Entities;                       // Contato
using ListaTelefonica.Api.Application.Queries;               // GetAllContatosQuery

namespace ListaTelefonica.Api.Application.Handlers
{
    public class GetAllContatosHandler : IRequestHandler<GetAllContatosQuery, IEnumerable<Contato>>
    {
        private readonly IContatoRepository _repo;

        public GetAllContatosHandler(IContatoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Contato>> Handle(GetAllContatosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}