using FluentValidation;
using MyEasyTicket.Domain.Entities;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;

namespace MyEasyTicket.Domain.Validations.Entities
{
    public class MovieValidation : AbstractValidator<Movie>
    {
        public MovieValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(m => m.Name).Length(3, 40).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Name", "from 3 to 40 caracters"));
        }
    }
}
