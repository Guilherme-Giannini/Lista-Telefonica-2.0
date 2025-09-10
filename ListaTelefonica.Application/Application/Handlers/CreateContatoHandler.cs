using MediatR;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Application.Abstractions.Repositories;
using System.Threading;
using System.Threading.Tasks;
using ListaTelefonica.Application.Application.Commands;

namespace ListaTelefonica.Application.Application.Handlers
{
    public class CreateContatoHandler : IRequestHandler<CreateContatoCommand, Contato>
    {
        private readonly IContatoRepository _contatoRepository;

        public CreateContatoHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Contato> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            await _contatoRepository.CreateAsync(request.Contato);
            return request.Contato;
        }
    }
}