using Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Emtelco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IMediator _mediator;

        public PokemonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("habilidadesOcultas/{pokemon}", Name = "BuscarPokemonPorNombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PokemonDetailVm>> BuscarPokemonPorNombre([FromRoute] string pokemon)
        {
            var getPokemonDetailQuery = new GetPokemonDetailQuery() { Pokemon = pokemon };
            var response = await _mediator.Send(getPokemonDetailQuery);

            if(response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await _mediator.Send(getPokemonDetailQuery));
            }
        }
    }
}
