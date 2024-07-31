namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class PokemonDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PokemonHabilidadesDto Habilidades { get; set; } = default!;
    }
}
