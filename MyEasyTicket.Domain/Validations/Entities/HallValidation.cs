using FluentValidation;
using MyEasyTicket.Domain.Entities;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;

namespace MyEasyTicket.Domain.Validations.Entities
{
    public class HallValidation : AbstractValidator<Hall>
    {
        public HallValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(h => h.HallIdentification).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(h => h.HallIdentification)
                .Length(1, 10).WithMessage(Message.MoreExpected.Description()
                .FormatMessage("Hall Indetification", "1 or 10 caracteres"));

            RuleFor(h => h.Seats).NotEmpty().WithMessage(Message.Required.Description());
        }
    }
}
