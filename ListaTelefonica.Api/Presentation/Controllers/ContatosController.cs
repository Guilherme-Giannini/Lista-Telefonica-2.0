using Microsoft.AspNetCore.Mvc;
using MediatR;
using ListaTelefonica.Api.Domain;
using ListaTelefonica.Api.Application.Commands;
using ListaTelefonica.Api.Application.Queries;
using System.Threading.Tasks;

namespace ListaTelefonica.Api.Presentation.Controllers
{
    [ApiController]
    [Route("contatos")]
    public class ContatosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContatosController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContatosQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var contato = await _mediator.Send(new GetContatoByIdQuery(id));
            if (contato == null) return NotFound();
            return Ok(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contato contato)
        {
            var created = await _mediator.Send(new CreateContatoCommand(contato));
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Contato contato)
        {
            var updated = await _mediator.Send(new UpdateContatoCommand(id, contato));
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _mediator.Send(new DeleteContatoCommand(id));
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}