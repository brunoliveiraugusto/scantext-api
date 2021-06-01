using FluentValidation;
using ScanText.Domain.Linguagem.Entities;
using ScanText.Domain.Shared.Validators.Messages;

namespace ScanText.Domain.Linguagem.Validators
{
    public class ArquivoIdiomaValidator : AbstractValidator<ArquivoIdioma>
    {
        public ArquivoIdiomaValidator()
        {
            RuleFor(i => i.IdIdioma)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Idioma"));
        }
    }
}
