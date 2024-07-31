using MediatR;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQueryHandler
        : IRequestHandler<GetPokemonDetailQuery, PokemonDetailVm>
    {
        public async Task<PokemonDetailVm> Handle(GetPokemonDetailQuery request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
