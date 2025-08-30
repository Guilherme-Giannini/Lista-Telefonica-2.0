using MediatR;

namespace ListaTelefonica.Api.Application.Commands
{
    public record DeleteContatoCommand(string Id) : IRequest<bool>;
}