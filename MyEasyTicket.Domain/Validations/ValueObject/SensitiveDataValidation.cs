using FluentValidation;
using MyEasyTicket.Domain.ValueObject;

namespace MyEasyTicket.Domain.Validations.ValueObject
{
    public class SensitiveDataValidation : AbstractValidator<SensitiveData>
    {
        public SensitiveDataValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(s => s.Document).NotEmpty().WithMessage("");
            RuleFor(s => s.Document).Length(11).WithMessage("");
        }
    }
}
