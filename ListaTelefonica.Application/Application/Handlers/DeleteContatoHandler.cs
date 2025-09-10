using MediatR;
using ListaTelefonica.Api.Application.Commands;

using ListaTelefonica.Application.Abstractions.Repositories;

namespace ListaTelefonica.Api.Application.Handlers
{
    public class DeleteContatoHandler : IRequestHandler<DeleteContatoCommand, bool>
    {
        private readonly IContatoRepository _repo;
        public DeleteContatoHandler(IContatoRepository repo) => _repo = repo;

        public async Task<bool> Handle(DeleteContatoCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing == null) return false;

            await _repo.DeleteAsync(request.Id);
            return true;
        }
    }
}