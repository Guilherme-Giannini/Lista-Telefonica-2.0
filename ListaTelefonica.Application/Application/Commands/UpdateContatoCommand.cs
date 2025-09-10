using MediatR;

namespace ListaTelefonica.Application.Commands
{
    public class UpdateContatoCommand : IRequest<bool>
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public List<string> Enderecos { get; set; } = new();
    }
}