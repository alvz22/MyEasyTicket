using FluentValidation;
using MyEasyTicket.Domain.Entities;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;

namespace MyEasyTicket.Domain.Validations.Entities
{
    public class TicketValidation : AbstractValidator<Ticket>
    {
        public TicketValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(t => t.FilmName).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(t => t.FilmName).Length(2, 50).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Film name", "from 2 to 50 caracters"));

            RuleFor(t => t.Information).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(t => t.Information).Length(3, 250).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Information", "from 10 to 250 caracters"));

            RuleFor(t => t.Price).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(t => t.Price).GreaterThan(0).WithMessage(Message.ValueExpected
                .Description().FormatMessage("Price", "0,00"));
        }
    }
}
