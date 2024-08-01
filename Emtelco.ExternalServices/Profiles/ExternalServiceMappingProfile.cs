using AutoMapper;
using Emtelco.Domain;
using Emtelco.ExternalServices.ExternalDataContract;

namespace Emtelco.ExternalServices.Profiles
{
    public class ExternalServiceMappingProfile : Profile
    {
        public ExternalServiceMappingProfile()
        {
            CreateMap<Pokemon, PokemonResponse>().ReverseMap();
        }
    }
}
