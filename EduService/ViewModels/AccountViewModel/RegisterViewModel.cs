using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduService.ViewModels.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(31, MinimumLength = 6, ErrorMessage = "FullName must be between 6 and 31 characters")]
        public string FullName { get; set; }
        [Required]
        [StringLength(31, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 31 characters")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 15 characters")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}