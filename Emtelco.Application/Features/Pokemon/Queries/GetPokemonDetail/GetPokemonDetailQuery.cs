using MediatR;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQuery
        : IRequest<PokemonDetailVm>
    {
        public string Name { get; set; } = default!;
    }
}
