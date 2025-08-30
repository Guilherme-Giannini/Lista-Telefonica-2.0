using MediatR;
using ListaTelefonica.Api.Domain;

namespace ListaTelefonica.Api.Application.Queries
{
    public record GetContatoByIdQuery(string Id) : IRequest<Contato>;
}