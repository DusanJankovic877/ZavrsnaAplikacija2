using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZavrsnaAplikacija2.Models
{
    public class AccountViewModels
    {
        public class LoginViewModel
        {
            [Required]
            [Display(Name = "UserName")]
            [DataType(DataType.Text)]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        public class RegisterViewModel
        {
            [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Display(Name = "UserRoles")]
            public string UserRoles { get; set; }

            [Required]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at least {2} charachters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password o not match.")]
            public string ConfirmPassword { get; set; }
        }
        public class ExternalLoginConfirmationViewModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

        }
        public class ExternalLoginListViewModel
        {
            [Required]
            [Display(Name = "ReturnUrl")]
            public string ReturnUrl { get; set;}
        }
    }
}