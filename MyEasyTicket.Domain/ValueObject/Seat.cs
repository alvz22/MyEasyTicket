using MyEasyTicket.Domain.Validations.ValueObject;

namespace MyEasyTicket.Domain.ValueObject
{
    public class Seat : BaseValueObject
    {

        public int Number { get; private set; }
        public bool Available { get; private set; }

        public Seat(int number)
        {
            this.Number = number;
            this.Available = true;

            Validate(this, new SeatValidation());
        }
    }
}
