using FluentValidation;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;
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
            RuleFor(a => a.CompleteAddress).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(a => a.CompleteAddress).Length(10, 150).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Complete Address", "from 10 to 150 caracters"));

            RuleFor(a => a.AddressNumber).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(a => a.AddressNumber).Length(1, 8).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Address number", "from 1 to 8 caracters"));

            RuleFor(a => a.City).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(a => a.City).Length(3, 70).WithMessage(Message.MoreExpected
                .Description().FormatMessage("City", "from 3 to 70 caracters"));

            RuleFor(a => a.State).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(a => a.State).Length(2, 40).WithMessage(Message.MoreExpected
                .Description().FormatMessage("State", "from 3 to 40 caracters"));

        }
    }
}
