using MyEasyTicket.Domain.Validations.Entities;
using MyEasyTicket.Domain.ValueObject;
using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Hall : BaseEntity
    {
        public string HallIndentification { get; private set; }
        public Dictionary<string, Seat> Seats { get; private set; }

        public int FilmId { get; set; }
        public Film Film { get; private set; }

        public Hall(string hallIndentification, int seatsNumber)
        {
            this.HallIndentification = hallIndentification;
            SetSeatsNumber(seatsNumber);

            Validate(this, new HallValidation());
        }


        public void HallUpdate(string hallIndentification, Film film, int seatsNumber)
        {
            this.HallIndentification = hallIndentification;
            this.Film = film;
            SetSeatsNumber(seatsNumber);

            Validate(this, new HallValidation());
        }

        private void SetSeatsNumber(int quantity)
        {
            this.Seats = new Dictionary<string, Seat>();
            int count;

            for (count = 1; count < quantity; count++)
            {
                this.Seats.Add($"Seat {count}", new Seat(count));
            }
        }
    }
}
