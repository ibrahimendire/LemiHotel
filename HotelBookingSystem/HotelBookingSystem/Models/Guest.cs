using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Models
{
    public class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public List<Checkout> Checkouts { get; set; }


        public int Id { get; set; }



        public Guest(string firstName, string lastName, string phone, string email, string address, DateTime checkinDate, DateTime checkoutDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;

        }
        public Guest()
        {

        }


        public override string ToString()
        {
            return FirstName + LastName;
        }

        public override bool Equals(object obj)
        {
            return obj is Guest guest &&
                   Id == guest.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }



    }
}
