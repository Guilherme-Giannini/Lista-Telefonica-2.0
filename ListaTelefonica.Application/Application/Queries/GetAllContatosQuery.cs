using MediatR;
using ListaTelefonica.Domain.Entities;

namespace ListaTelefonica.Api.Application.Queries
{
    public class GetAllContatosQuery : IRequest<IEnumerable<Contato>>
    {
    }
}