using MyEasyTicket.Domain.Validations.Entities;
using System;

namespace MyEasyTicket.Domain.Entities
{
    public class Poster : BaseEntity
    {
        public Film Film { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinalDate { get; private set; }

        public Poster(Film film, DateTime startDate, DateTime finalDate)
        {
            this.Film = film;
            this.StartDate = startDate;
            this.FinalDate = finalDate;

            Validate(this, new PosterValidation());
        }
    }
}
