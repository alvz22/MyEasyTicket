using FluentValidation;
using FluentValidation.Results;

namespace MyEasyTicket.Domain.ValueObject
{
    public abstract class BaseValueObject
    {
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TValueObject>(TValueObject valueObject, AbstractValidator<TValueObject> validator)
        {
            ValidationResult = validator.Validate(valueObject);
            return Valid = ValidationResult.IsValid;
        }
    }
}
