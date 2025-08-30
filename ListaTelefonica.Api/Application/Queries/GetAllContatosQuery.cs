using MediatR;
using System.Collections.Generic;
using ListaTelefonica.Api.Domain;

namespace ListaTelefonica.Api.Application.Queries
{
    public record GetAllContatosQuery() : IRequest<IEnumerable<Contato>>;
}