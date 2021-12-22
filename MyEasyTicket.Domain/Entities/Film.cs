using System;

namespace MyEasyTicket.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Duration { get; private set; }
        public decimal TicketPrice { get; private set; }


        public Film(string name, string description, DateTime duration, decimal ticketprice)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.TicketPrice = ticketprice;
        }
    }
}
