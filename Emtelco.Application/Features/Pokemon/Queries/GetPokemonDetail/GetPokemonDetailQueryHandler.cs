using AutoMapper;
using Emtelco.Application.Contracts.ExternalServices;
using MediatR;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQueryHandler
        : IRequestHandler<GetPokemonDetailQuery, PokemonDetailVm>
    {
        public readonly IPokemonExternalService _pokemonExternalService;
        public readonly IMapper _mapper;

        public GetPokemonDetailQueryHandler(IPokemonExternalService pokemonExternalService,
            IMapper mapper)
        {
            _mapper = mapper;
            _pokemonExternalService = pokemonExternalService;
        }

        public async Task<PokemonDetailVm> Handle(GetPokemonDetailQuery request,
            CancellationToken cancellationToken)
        {
            var pokemon = await _pokemonExternalService.GetPokemonByName(request.Name);

            return _mapper.Map<PokemonDetailVm>(pokemon);
        }
    }
}
