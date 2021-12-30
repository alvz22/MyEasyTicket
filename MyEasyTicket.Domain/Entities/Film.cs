using MyEasyTicket.Domain.Validations.Entities;
using System;

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
            this.CreationDate = DateTime.Now;

            Validate(this, new FilmValidation());
        }

        public void UpdateFilm(string name, string description, string duration, decimal ticketprice)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.TicketPrice = ticketprice;
            this.UpdateDate = DateTime.Now;

            Validate(this, new FilmValidation());
        }
    }
}
