using System;
using System.ComponentModel.DataAnnotations;
namespace LemiHotel.ViewModels
{
    public class AddRoomCategoryViewModel
    {
        [Required(ErrorMessage = "please Enter Room Number")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 8 character")]
        public string Name { get; set; }
    }
}
