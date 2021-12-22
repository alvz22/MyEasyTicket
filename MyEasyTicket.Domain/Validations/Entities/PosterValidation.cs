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
            RuleFor(p => p.Film).NotEmpty().WithMessage(Message.Required.Description());

            RuleFor(p => p.StartDate).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(p => p.FinalDate).NotEmpty().WithMessage(Message.Required.Description());
        }
    }
}
