using AutoMapper;
using Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail;
using Emtelco.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
