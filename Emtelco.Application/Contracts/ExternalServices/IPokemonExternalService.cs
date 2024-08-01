using Emtelco.Domain;

namespace Emtelco.Application.Contracts.ExternalServices
{
    public interface IPokemonExternalService
    {
        Task<Pokemon?> GetPokemonByName(string name);
    }
}
