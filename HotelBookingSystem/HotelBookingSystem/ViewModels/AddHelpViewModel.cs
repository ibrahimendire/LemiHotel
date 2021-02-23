using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.ViewModels
{
    public class AddHelpViewModel
    {
        [Required(ErrorMessage = "please Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "please Enter Last Name")]
        public string LastName { get; set; }

       [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "please Enter Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "please Select your issue")]
        public string Issue { get; set; }
        [Required(ErrorMessage = "please Enter some  note")]
        public string HelpText { get; set; }

    }
}
