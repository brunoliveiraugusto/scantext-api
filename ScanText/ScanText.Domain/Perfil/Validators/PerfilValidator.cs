using FluentValidation;
using ScanText.Domain.Utils.Validators.Messages;
using Entitie = ScanText.Domain.Perfil.Entities;

namespace ScanText.Domain.Perfil.Validators
{
    public class PerfilValidator : AbstractValidator<Entitie.Perfil>
    {
        public PerfilValidator()
        {
            RuleFor(d => d.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Descrição"));

            RuleFor(s => s.Sigla)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Sigla"));
        }
    }
}
