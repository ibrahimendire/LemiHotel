using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.ViewModels
{
    public class AddGuestViewModel
    {
        [Required(ErrorMessage = "please enter First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "please enter Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "please enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter Address")]
        public string Address { get; set; }

      
        public string Address2 { get; set; }
        [Required(ErrorMessage = "please enter City ")]
        public string City { get; set; }
        [Required(ErrorMessage = "please Select State ")]
        public string State { get; set; }
        [Required(ErrorMessage = "please enter Zip code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "please Slect CheckInDate")]
        public DateTime CheckinDate { get; set; }

        [Required(ErrorMessage = "please Select CheckoutDate")]
        public DateTime CheckoutDate { get; set; }

        [Required(ErrorMessage = "please Select Room")]
        public int RoomId { get; set; }
        public List<SelectListItem> Rooms { get; set; }

        public AddGuestViewModel(List<Room> rooms)
        {
            Rooms = new List<SelectListItem>();

            foreach (var room in rooms)
            {
                Rooms.Add(new SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = room.Name
                });
            }
        }
        public AddGuestViewModel()
        {

        }

    }
}
