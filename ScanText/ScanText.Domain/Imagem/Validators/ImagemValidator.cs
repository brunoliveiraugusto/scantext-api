using FluentValidation;
using ScanText.Domain.Utils.Validators.Messages;
using Entitie = ScanText.Domain.Imagem.Entities;

namespace ScanText.Domain.Imagem.Validators
{
    public class ImagemValidator : AbstractValidator<Entitie.Imagem>
    {
        public ImagemValidator()
        {
            RuleFor(x => x.Linguagem)
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Idioma"));
        }
    }
}
