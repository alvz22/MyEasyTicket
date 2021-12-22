using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Hall : BaseEntity
    {
        public string HallIndentification { get; private set; }
        public Film Film { get; private set; }
        public Dictionary<string, Seat> Seats { get; private set; }

        public Hall(string hallIndentification, Film movie, int seatsNumber)
        {
            this.HallIndentification = hallIndentification;
            this.Film = movie;
            SetSeatsNumber(seatsNumber);

        }

        private void SetSeatsNumber(int quantity)
        {
            this.Seats = new Dictionary<string, Seat>();
            int count;

            for (count = 1; count == quantity; count++)
            {
                this.Seats.Add($"Seat {count}", new Seat(count));
            }
        }
    }
}
