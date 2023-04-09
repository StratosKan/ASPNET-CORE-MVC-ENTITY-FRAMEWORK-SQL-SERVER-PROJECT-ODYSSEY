using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")] //localization
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
