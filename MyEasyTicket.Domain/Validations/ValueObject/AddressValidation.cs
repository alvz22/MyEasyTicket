using FluentValidation;
using MyEasyTicket.Domain.ValueObject;

namespace MyEasyTicket.Domain.Validations.ValueObject
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(a => a.CompleteAddress).NotEmpty().WithMessage("");
            RuleFor(a => a.CompleteAddress).Length(10, 150).WithMessage("");

            RuleFor(a => a.AddressNumber).NotEmpty().WithMessage("");
            RuleFor(a => a.AddressNumber).Length(1, 8).WithMessage("");

            RuleFor(a => a.City).NotEmpty().WithMessage("");
            RuleFor(a => a.City).Length(3, 70).WithMessage("");

            RuleFor(a => a.State).NotEmpty().WithMessage("");
            RuleFor(a => a.State).Length(3, 40).WithMessage("");

        }
    }
}
