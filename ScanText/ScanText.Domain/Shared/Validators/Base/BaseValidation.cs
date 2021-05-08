
using FluentValidation;

namespace ScanText.Domain.Shared.Validators.Base
{
    public class BaseValidation<T> : AbstractValidator<T> where T : class
    {
    }
}
