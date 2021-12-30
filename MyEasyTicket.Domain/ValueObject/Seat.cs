using MyEasyTicket.Domain.Validations.ValueObject;

namespace MyEasyTicket.Domain.ValueObject
{
    public class Seat : BaseValueObject
    {

        public int Number { get; private set; }
        public bool Available { get; private set; }

        public Seat(int number)
        {
            if (number > 0)
            {
                this.Number = number;
            }


            Validate(this, new SeatValidation());

            if (this.Valid)
            {
                this.Available = true;
            }
        }
    }
}
