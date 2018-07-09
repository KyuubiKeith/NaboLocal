using System.ComponentModel.DataAnnotations;
using System;

namespace NaboUI.Models
{
    public class RegisterViewModel
    {
        //attributes
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Adress")]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "ConfirmPassword") ]
        [Compare("Password", ErrorMessage = "Passwords Do not match")]
        public string ConfirmPassword { get; set; }

    }
}