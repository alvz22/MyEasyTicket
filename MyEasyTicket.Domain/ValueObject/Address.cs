using MyEasyTicket.Domain.Validations.ValueObject;

namespace MyEasyTicket.Domain.ValueObject
{
    public class Address : BaseValueObject
    {
        public string CompleteAddress { get; private set; }
        public string AddressNumber { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Address(string completeAddress, string addressNumber, string city, string state)
        {
            this.CompleteAddress = completeAddress;
            this.AddressNumber = addressNumber;
            this.City = city;
            this.State = state;

            Validate(this, new AddressValidation());
        }

        public void UpdateAddress(string completeAddress, string addressNumber, string city, string state)
        {
            this.CompleteAddress = completeAddress;
            this.AddressNumber = addressNumber;
            this.City = city;
            this.State = state;

            Validate(this, new AddressValidation());
        }
    }
}
