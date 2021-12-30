using MyEasyTicket.Domain.Validations.Entities;
using MyEasyTicket.Domain.ValueObject;
using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Hall : BaseEntity
    {
        public string HallIdentification { get; private set; }
        public Dictionary<string, Seat> Seats { get; private set; }

        public int FilmId { get; set; }
        public Film Film { get; private set; }

        public Hall(string hallIdentification, int seatsNumber)
        {
            this.HallIdentification = hallIdentification;
            SetSeatsNumber(seatsNumber);

            Validate(this, new HallValidation());
        }


        public void UpdateHall(string hallIndentification, int seatsNumber)
        {
            this.HallIdentification = hallIndentification;
            SetSeatsNumber(seatsNumber);

            Validate(this, new HallValidation());
        }

        private void SetSeatsNumber(int quantity)
        {
            this.Seats = new Dictionary<string, Seat>();
            int count;

            if (quantity > 0)
            {

                for (count = 0; count < quantity; count++)
                {
                    this.Seats.Add($"Seat {count + 1}", new Seat(count + 1));
                }
            }
        }
    }
}
