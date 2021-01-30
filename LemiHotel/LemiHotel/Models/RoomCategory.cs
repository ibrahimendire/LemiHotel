using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LemiHotel.Models
{
    public class RoomCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Room> Rooms { get; set; }
        public RoomCategory(string name)
        {
            Name = name;
        }
        public RoomCategory()
        {

        }
    }
}
