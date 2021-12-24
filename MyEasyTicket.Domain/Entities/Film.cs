using MyEasyTicket.Domain.Validations.Entities;

namespace MyEasyTicket.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Duration { get; private set; }
        public decimal TicketPrice { get; private set; }


        public Film(string name, string description, string duration, decimal ticketprice)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.TicketPrice = ticketprice;

            Validate(this, new FilmValidation());
        }

        public void FilmUpdate(string name, string description, string duration, decimal ticketprice)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.TicketPrice = ticketprice;

            Validate(this, new FilmValidation());
        }
    }
}
