using MyEasyTicket.Domain.Validations.Entities;
using MyEasyTicket.Domain.ValueObject;
using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }


        public int HallId { get; set; }
        public IEnumerable<Hall> Halls { get;  set; }

        public Movie(string name, Address address)
        {
            this.Name = name;
            this.Address = address;

            Validate(this, new MovieValidation());
        }

        public void MovieUpdate(string name, Address address)
        {
            this.Name = name;
            this.Address = address;

            Validate(this, new MovieValidation());
        }

    }
}
