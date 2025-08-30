using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ListaTelefonica.Api.Infrastructure.Repositories;
using ListaTelefonica.Api.Application.Commands;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class UpdateContatoHandler : IRequestHandler<UpdateContatoCommand, bool>
    {
        private readonly IContatoRepository _repo;
        public UpdateContatoHandler(IContatoRepository repo) => _repo = repo;

        public async Task<bool> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
        {
            // garantir que o Id da entidade esteja sincronizado
            request.Contato.Id = request.Id;

            // opcional: checar existência (GetByIdAsync) para retornar false se não existir
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing == null) return false;

            await _repo.UpdateAsync(request.Contato);
            return true;
        }
    }
}