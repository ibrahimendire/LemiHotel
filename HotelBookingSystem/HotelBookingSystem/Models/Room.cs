
using System;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public RoomCategory Category { get; set; }
        public int CategoryId { get; set; }
         public int Id { get; set; }
      
        public Room()
        {
      
        }

        public Room(string name ,string price)//:this()
        {
            Name = name;
            Price = price;   
        }
   

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   Id == room.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
