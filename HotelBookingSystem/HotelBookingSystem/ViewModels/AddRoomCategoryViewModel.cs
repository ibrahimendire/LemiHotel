using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.ViewModels
{
    public class AddRoomCategoryViewModel
    {
        [Required(ErrorMessage = "please Enter Room Number")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 8 character")]
        public string Name { get; set; }
    }
}
