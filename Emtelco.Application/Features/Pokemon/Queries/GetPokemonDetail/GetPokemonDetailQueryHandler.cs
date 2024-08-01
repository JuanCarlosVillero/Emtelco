using AutoMapper;
using Emtelco.Application.Contracts.ExternalServices;
using MediatR;
using System.Runtime.ConstrainedExecution;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQueryHandler
        : IRequestHandler<GetPokemonDetailQuery, PokemonDetailVm>
    {
        private const int CERO = 0;

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
            var validator = new GetPokemonDetailQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > CERO)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var pokemon = await _pokemonExternalService.GetPokemonByName(request.Pokemon);

            return _mapper.Map<PokemonDetailVm>(pokemon);
        }
    }
}
