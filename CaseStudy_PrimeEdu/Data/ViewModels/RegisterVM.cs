using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Public name")]
        [Required(ErrorMessage = "Public name is required")]
        public string PublicName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")] //localization
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm Password is required")] 
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]

        public string ConfirmPassword { get; set; }
    }
}
