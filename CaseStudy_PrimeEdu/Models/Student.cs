using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int InstallationId { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; } // BIO/DETAILS

        [Display(Name = "Member Since")]
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 25 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 25 characters")]
        public string? LastName { get; set; }

        public string? Title { get; set; } // --UNUSED
        public string? ProfilePictureURL { get; set; }


        //RLs
        public List<Course_Student>? Course_Students { get; set; }

        public int activeCourseId { get; set; }
    }
}
