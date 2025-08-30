using MediatR;
using ListaTelefonica.Api.Domain;

namespace ListaTelefonica.Api.Application.Commands
{
    public record UpdateContatoCommand(string Id, Contato Contato) : IRequest<bool>;
}