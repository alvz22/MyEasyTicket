using MyEasyTicket.Domain.Validations.Entities;

namespace MyEasyTicket.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string FilmName { get; private set; }
        public string Information { get; private set; }
        public decimal Price { get; private set; }


        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public Ticket(string filmName, string information, decimal price)
        {
            this.FilmName = filmName;
            this.Information = information;
            this.Price = price;

            Validate(this, new TicketValidation());
        }

        public void UpdateTicket(string filmName, string information, decimal price)
        {
            this.FilmName = filmName;
            this.Information = information;
            this.Price = price;

            Validate(this, new TicketValidation());
        }
    }
}
