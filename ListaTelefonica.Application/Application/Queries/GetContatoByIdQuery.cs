using MediatR;
using ListaTelefonica.Domain.Entities;

namespace ListaTelefonica.Api.Application.Queries
{
    public record GetContatoByIdQuery(string Id) : IRequest<Contato?>;
}