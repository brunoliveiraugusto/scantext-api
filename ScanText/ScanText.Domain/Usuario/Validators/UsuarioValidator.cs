using FluentValidation;
using ScanText.Domain.Utils.Validators.Messages;
using Entitie = ScanText.Domain.Usuario.Entities;

namespace ScanText.Domain.Usuario.Validators
{
    public class UsuarioValidator : AbstractValidator<Entitie.Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio(""));

            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio(""));

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio(""));

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio(""));

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio(""));
        }
    }
}
