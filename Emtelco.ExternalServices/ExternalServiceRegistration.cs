using Emtelco.Application.Contracts.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace Emtelco.ExternalServices
{
    public static class ExternalServiceRegistration
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpClient("pokemon", x =>
            {
                x.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            });

            services.AddSingleton<IPokemonExternalService, PokemonExternalService>();

            return services;
        }
    }
}
