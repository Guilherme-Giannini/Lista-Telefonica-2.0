using MediatR;
using ListaTelefonica.Api.Domain;

namespace ListaTelefonica.Api.Application.Commands
{
    public record CreateContatoCommand(Contato Contato) : IRequest<Contato>;
}