using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingSystem.Models;


namespace HotelBookingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HotelBookingSystem.Models.Room> Room { get; set; }
        public DbSet<HotelBookingSystem.Models.RoomCategory> RoomCategory { get; set; }
        public DbSet<HotelBookingSystem.Models.Guest> Guest { get; set; }
        public DbSet<HotelBookingSystem.Models.Checkout> Checkout { get; set; }
        public DbSet<HotelBookingSystem.Models.Help> Help { get; set; }
    }
}
