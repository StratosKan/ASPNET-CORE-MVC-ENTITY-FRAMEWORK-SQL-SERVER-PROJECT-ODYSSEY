using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public int InstallationId { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        public bool Enabled { get; set; }
        public bool Active { get; set; }
    }
}
