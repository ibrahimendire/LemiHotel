using LemiHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LemiHotel.Data
{
    public class RoomDbContext:DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCategory> Categories { get; set; }
        public RoomDbContext(DbContextOptions<RoomDbContext> options)
              : base(options)
        {
        }

    }
}
