using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LemiHotel.Models;

namespace HotelBookingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LemiHotel.Models.Room> Room { get; set; }
        public DbSet<LemiHotel.Models.RoomCategory> RoomCategory { get; set; }
    }
}
