using CaseStudy_PrimeEdu.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Models
{
    public class Test
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int InstallationId { get; set; }

        [Display(Name = "Test Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Category")]
        public string? TestCategory { get; set; }

        public int? Status { get; set; }
        [Display(Name = "Grade")]
        public int? Grade { get; set; }
        [Display(Name = "Pass/Fail")]
        public bool Result { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? CreationDate { get; set; }
        public DateTime StartDate { get; set; } //UNUSED
        public DateTime EndDate { get; set; } //UNUSED
        public DateTime LastModifiedDate { get; set;}
        public DateTime ModifiedTime { get; set;}   //UNUSED
        public DateTime ModifiedTimeUtc { get; set; } //UNUSED

        //RLs

        public List<Course_Test>? Course_Tests { get; set; }
        public List<Course>? CourseList { get; set; }        
        public int CourseId { get; set; }
    }
}
