using System;

namespace MyEasyTicket.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinalDate { get; private set; }

        public Movie(string name, string description, decimal price, DateTime startDate, DateTime finalDate)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.StartDate = startDate;
            this.FinalDate = finalDate;
        }
    }
}
