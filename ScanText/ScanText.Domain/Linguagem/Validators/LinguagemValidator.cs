using FluentValidation;
using ScanText.Domain.Utils.Validators.Messages;
using Entitie = ScanText.Domain.Linguagem.Entities;

namespace ScanText.Domain.Linguagem.Validators
{
    public class LinguagemValidator : AbstractValidator<Entitie.Linguagem>
    {
        public LinguagemValidator()
        {
            RuleFor(i => i.Idioma)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Idioma"));

            RuleFor(s => s.Sigla)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Sigla"));
        }
    }
}
