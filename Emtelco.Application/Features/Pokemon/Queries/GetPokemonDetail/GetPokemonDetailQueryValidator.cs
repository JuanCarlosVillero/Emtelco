using FluentValidation;

namespace Emtelco.Application.Features.Pokemon.Queries.GetPokemonDetail
{
    public class GetPokemonDetailQueryValidator
        : AbstractValidator<GetPokemonDetailQuery>
    {
        public GetPokemonDetailQueryValidator()
        {
            RuleFor(p => p.Pokemon)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .Matches("^[A-Za-z]+$")
                .WithMessage("{PropertyName} solo debe contener letras o vocales.");
        }
    }
}
