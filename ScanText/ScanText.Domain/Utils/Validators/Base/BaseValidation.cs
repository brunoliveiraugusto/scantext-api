
using FluentValidation;

namespace ScanText.Domain.Utils.Validators.Base
{
    public class BaseValidation<T> : AbstractValidator<T> where T : class
    {
    }
}
