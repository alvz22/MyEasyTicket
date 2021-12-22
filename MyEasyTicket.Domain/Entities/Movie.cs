using MyEasyTicket.Domain.ValueObject;
using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public IEnumerable<Hall> Rooms { get;  set; }

        public Movie(string name, Address address, IEnumerable<Hall> rooms)
        {
            this.Name = name;
            this.Address = address;
            this.Rooms = rooms;
        }
    }
}
