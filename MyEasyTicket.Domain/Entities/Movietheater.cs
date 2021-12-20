using MyEasyTicket.Domain.ValueObject;
using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Movietheater : BaseEntity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public IEnumerable<Room> Rooms { get;  set; }

        public Movietheater(string name, Address address, IEnumerable<Room> rooms)
        {
            this.Name = name;
            this.Address = address;
            this.Rooms = rooms;
        }
    }
}
