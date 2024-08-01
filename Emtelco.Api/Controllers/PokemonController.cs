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
        public async Task<IActionResult> BuscarPokemonPorNombre([FromRoute] string pokemon)
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
