using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazzar.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        

        [StringLength(20, ErrorMessage = "Username must be between 4 and 20 symbols long.", MinimumLength = 4)]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Username must be contain only letters.")]
        public string UserName { get; set; }

        [RegularExpression("^[+][0-9]\\d{10,12}", ErrorMessage = "Phone must be start with “+“ and between 10 and 12 symbols long.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
