using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Infrastructure.Repositories;
using ListaTelefonica.Api.Application.Commands;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class CreateContatoHandler : IRequestHandler<CreateContatoCommand, Contato>
    {
        private readonly IContatoRepository _repo;
        public CreateContatoHandler(IContatoRepository repo) => _repo = repo;

        public async Task<Contato> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            await _repo.CreateAsync(request.Contato);
            return request.Contato;
        }
    }
}