using ListaTelefonica.Application.Abstractions.Repositories;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Application.Commands;
using MediatR;

namespace ListaTelefonica.Application.Handlers
{
    public class UpdateContatoHandler : IRequestHandler<UpdateContatoCommand, bool>
    {
        private readonly IContatoRepository _contatoRepository;

        public UpdateContatoHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<bool> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = new Contato
            {
                Id = request.Id,
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Enderecos = request.Enderecos?.ToList() ?? new List<string>()
            };

            try
            {
                await _contatoRepository.UpdateAsync(contato); // não retorna nada
                return true; // se chegou aqui, deu certo
            }
            catch
            {
                return false; // em caso de erro, retorna false
            }
        }
    }
}