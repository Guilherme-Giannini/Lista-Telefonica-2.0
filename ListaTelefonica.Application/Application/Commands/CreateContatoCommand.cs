using MediatR;
using ListaTelefonica.Domain.Entities;

namespace ListaTelefonica.Application.Application.Commands
{
    public record CreateContatoCommand(Contato Contato) : IRequest<Contato>;
}