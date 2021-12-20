using MyEasyTicket.Domain.Validations.ValueObject;

namespace MyEasyTicket.Domain.ValueObject
{
    public class SensitiveData : BaseValueObject
    {
        public string Document { get; private set; }

        public SensitiveData(string document)
        {
            this.Document = document;

            Validate(this, new SensitiveDataValidation());
        }
    }
}
