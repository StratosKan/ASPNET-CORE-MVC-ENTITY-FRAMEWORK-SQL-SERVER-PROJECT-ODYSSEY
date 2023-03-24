using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CaseStudy_PrimeEdu.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int InstallationId { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Display(Name ="Description")]
        public string? Description { get; set; } //  BIO/DETAILS
        [Display(Name ="Member Since")]
        public DateTime CreationDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 25 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 25 characters")]
        public string? LastName { get; set; }
        
        public string? ProfilePictureURL { get; set; }
        

        //RLs
        public List<Course>? Courses { get; set; }
    }
}
