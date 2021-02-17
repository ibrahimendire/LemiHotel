using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Models
{
    public class Checkout
    {
        public string Note { get; set; }
        public Guest Guest { get; set; }
        public int GuestId { get; set; }
        public int Id { get; set; }

        public Checkout()
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Note;
        }
    }
}
