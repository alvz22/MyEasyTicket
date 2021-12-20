namespace MyEasyTicket.Domain.Entities
{
    public class Seat : BaseEntity
    {

        public int Number { get; private set; }
        public string Section { get; private set; }

        public Seat(int number, string section)
        {
            this.Number = number;
            this.Section = section;
        }
    }
}
