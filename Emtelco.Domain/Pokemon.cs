namespace Emtelco.Domain
{
    public class Pokemon : IBusinessEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PokemonHabilidades Habilidades { get; set; } = default!;
    }
}
