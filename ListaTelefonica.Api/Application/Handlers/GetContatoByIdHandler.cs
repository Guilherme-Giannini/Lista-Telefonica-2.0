using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Infrastructure.Repositories;
using ListaTelefonica.Api.Application.Queries;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class GetContatoByIdHandler : IRequestHandler<GetContatoByIdQuery, Contato>
    {
        private readonly IContatoRepository _repo;
        public GetContatoByIdHandler(IContatoRepository repo) => _repo = repo;

        public async Task<Contato> Handle(GetContatoByIdQuery request, CancellationToken cancellationToken)
            => await _repo.GetByIdAsync(request.Id);
    }
}