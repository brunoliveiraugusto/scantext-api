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
                .WithMessage(ValidationMessages.CampoObrigatorio("Usuário"));

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Senha"));

            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Nome Completo"));

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage(ValidationMessages.CampoObrigatorio("E-mail"));

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidationMessages.CampoObrigatorio("Data de Nascimento"));
        }
    }
}
