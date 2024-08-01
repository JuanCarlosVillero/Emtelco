using AutoMapper;
using Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail;
using Emtelco.Domain;

namespace Emtelco.Application.Profiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Pokemon, PokemonDetailVm>().ReverseMap();
            CreateMap<PokemonHabilidades, PokemonHabilidadesDto>().ReverseMap();
        }
    }
}
