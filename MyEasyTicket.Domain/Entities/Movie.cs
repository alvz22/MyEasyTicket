using MyEasyTicket.Domain.ValueObject;
using System.Collections.Generic;

namespace MyEasyTicket.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public Dictionary<string, Hall> Rooms { get;  set; }

        public Movie(string name, Address address, Dictionary<string, Hall> rooms)
        {
            this.Name = name;
            this.Address = address;
            this.Rooms = rooms;
        }

        //criar metodo para adicionar a quantidade de salas do cinema.
    }
}
