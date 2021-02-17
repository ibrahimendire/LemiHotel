using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.ViewModels
{
    public class AddCheckoutViewModel
    {

        [Required(ErrorMessage = "please Enter some  note")]
        public string Note { get; set; }
        public Guest Guest { get; set; }
        public int GuestId { get; set; }


        public List<SelectListItem> Guests { get; set; }

        public AddCheckoutViewModel(List<Guest> guests)
        {
            Guests = new List<SelectListItem>();

            foreach (var guest in guests)
            {
                Guests.Add(new SelectListItem
                {
                    Value = guest.Id.ToString(),
                    Text = guest.LastName
                });
            }
        }
        public AddCheckoutViewModel()
        {
                
        }

    }
}
