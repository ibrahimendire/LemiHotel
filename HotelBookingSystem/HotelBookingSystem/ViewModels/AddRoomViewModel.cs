
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.ViewModels
{
    public class AddRoomViewModel
    {
        [Required(ErrorMessage = "please enter Name")]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 8 character")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please Enter price")]
        [StringLength(4, ErrorMessage = "Price too high")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Room Type is Required")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public AddRoomViewModel(List<RoomCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }
        public AddRoomViewModel()
        {

        }
    }
}
