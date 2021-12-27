using FluentValidation;
using FluentValidation.Results;
using System;

namespace MyEasyTicket.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected int Id { get; private set; }
        protected DateTime CreationDate { get; set; }
        protected DateTime UpdateDate { get; set; }

        public bool Valid { get; private set; }
        public bool Invalid => !Valid;

        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            ValidationResult = validator.Validate(entity);
            return Valid = ValidationResult.IsValid;
        }
    }
}
