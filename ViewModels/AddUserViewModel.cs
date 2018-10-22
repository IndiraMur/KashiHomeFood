using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KashiHomeFood.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Verify Password")]
        public string Verify { get; set; }

    }
}
