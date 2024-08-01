using AutoMapper;
using Emtelco.Domain;
using Emtelco.ExternalServices.ExternalDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
