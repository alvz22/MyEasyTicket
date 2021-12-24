using FluentValidation;
using MyEasyTicket.Domain.Entities;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;

namespace MyEasyTicket.Domain.Validations.Entities
{
    public class FilmValidation : AbstractValidator<Film>
    {
        public FilmValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(f => f.Name).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(f => f.Name).Length(3, 50).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Name", "from 3 to 50 caracters"));

            RuleFor(f => f.Description).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(f => f.Description).Length(3, 100).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Description", "from 3  to 100 caracters"));

            RuleFor(f => f.Duration).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(f => f.Duration).Length(3, 10).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Duration", "from 3 to 10 caracters"));

            RuleFor(f => f.TicketPrice).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(f => f.TicketPrice).GreaterThan(0).WithMessage(Message.ValueExpected
                .Description().FormatMessage("Value", "0,00"));

        }
    }
}
