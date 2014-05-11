using System.ComponentModel.DataAnnotations;

namespace imgcrv.Presentation.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Dabartinis slaptažodis")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} turi būti sudarytas iš bent {2} ženklų.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Naujas slaptažodis")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Pakartokite naują slaptažodį")]
        [Compare("NewPassword", ErrorMessage = "Slaptažodžiai nesutampa.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [Display(Name = "Prisiminti?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} turi būti sudarytas iš bent {2} ženklų.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Pakartokite slaptažodį")]
        [Compare("Password", ErrorMessage = "Slaptažodžiai nesutampa.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "El. paštas")]
        public string Email { get; set; }
    }
}
