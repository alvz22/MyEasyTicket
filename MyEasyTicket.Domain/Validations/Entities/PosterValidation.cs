using FluentValidation;
using MyEasyTicket.Domain.Entities;
using MyEasyTicket.Domain.Extentions;
using MyEasyTicket.Domain.Validations.Resource;

namespace MyEasyTicket.Domain.Validations.Entities
{
    public class PosterValidation : AbstractValidator<Poster>
    {
        public PosterValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(p => p.Description).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(p => p.Description).Length(10, 250).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Description", "from 10 to 250 caracters"));

            RuleFor(p => p.ImgUrl).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(p => p.ImgUrl).Length(3, 250).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Img", "from 3 to 250 caracters"));
        }
    }
}
