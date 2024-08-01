using AutoMapper;
using Emtelco.Application.Contracts.ExternalServices;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Runtime.ConstrainedExecution;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQueryHandler
        : IRequestHandler<GetPokemonDetailQuery, PokemonDetailVm>
    {
        private const int CERO = 0;

        public readonly IPokemonExternalService _pokemonExternalService;
        public readonly IMapper _mapper;
        private readonly ILogger<GetPokemonDetailQueryHandler> _logger;

        public GetPokemonDetailQueryHandler(IPokemonExternalService pokemonExternalService,
            IMapper mapper,
            ILogger<GetPokemonDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _pokemonExternalService = pokemonExternalService;
            _logger = logger;
        }

        public async Task<PokemonDetailVm> Handle(GetPokemonDetailQuery request,
            CancellationToken cancellationToken)
        {
            var validator = new GetPokemonDetailQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > CERO)
            {
                _logger.LogError($"Error al consultar el pokemon: {request.Pokemon}");
                throw new Exceptions.ValidationException(validationResult);
            }

            var pokemon = await _pokemonExternalService.GetPokemonByName(request.Pokemon);

            return _mapper.Map<PokemonDetailVm>(pokemon);
        }
    }
}
