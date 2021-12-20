using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEasyTicket.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; private set; }
        public Movie Movie { get; private set; }
        public IEnumerable<Seat> Seats { get; private set; }
    }
}
