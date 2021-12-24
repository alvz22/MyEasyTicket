using FluentValidation;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;
using MyEasyTicket.Domain.ValueObject;

namespace MyEasyTicket.Domain.Validations.ValueObject
{
    public class SeatValidation : AbstractValidator<Seat>
    {
        public SeatValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(s => s.Number).NotEmpty().WithMessage(Message.Required.Description());
        }
    }
}
