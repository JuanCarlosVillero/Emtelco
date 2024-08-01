using MediatR;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQuery
        : IRequest<PokemonDetailVm>
    {
        public string Pokemon { get; set; } = default!;
    }
}
