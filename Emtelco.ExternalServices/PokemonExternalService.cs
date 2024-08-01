using AutoMapper;
using Emtelco.Application.Contracts.ExternalServices;
using Emtelco.Domain;
using Emtelco.ExternalServices.ExternalDataContract;
using Newtonsoft.Json;

namespace Emtelco.ExternalServices
{
    public class PokemonExternalService
        : IPokemonExternalService
    {
        public readonly IMapper _mapper;
        public readonly IHttpClientFactory _httpClientFactory;

        public PokemonExternalService(IMapper mapper,
            IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Pokemon?> GetPokemonByName(string name)
        {
            Pokemon pokemon = null;

            var httpClient = _httpClientFactory.CreateClient("pokemon");

            var response = await httpClient.GetAsync($"pokemon/{name}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                
                var content = JsonConvert.DeserializeObject<PokemonResponse>(result);

                pokemon = _mapper.Map<Pokemon>(content);

                var ocultas = content?.abilities
                    .ToList()
                    .Where(x => x.is_hidden == true)
                    .Select(x => x.ability.name)
                    .ToList();

                pokemon.Habilidades.Ocultas = ocultas;
            }

            return pokemon;
        }
    }
}
