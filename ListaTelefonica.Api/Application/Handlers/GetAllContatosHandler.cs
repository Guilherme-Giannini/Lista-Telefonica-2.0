using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Infrastructure.Repositories;
using ListaTelefonica.Api.Application.Queries;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class GetAllContatosHandler : IRequestHandler<GetAllContatosQuery, IEnumerable<Contato>>
    {
        private readonly IContatoRepository _repo;
        public GetAllContatosHandler(IContatoRepository repo) => _repo = repo;

        public async Task<IEnumerable<Contato>> Handle(GetAllContatosQuery request, CancellationToken cancellationToken)
            => await _repo.GetAllAsync();
    }
}