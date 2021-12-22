namespace MyEasyTicket.Domain.Entities
{
    public class Seat : BaseEntity
    {

        public int Number { get; private set; }
        public bool Available { get; private set; }

        public Seat(int number)
        {
            this.Number = number;
            this.Available = true;
        }
    }
}
