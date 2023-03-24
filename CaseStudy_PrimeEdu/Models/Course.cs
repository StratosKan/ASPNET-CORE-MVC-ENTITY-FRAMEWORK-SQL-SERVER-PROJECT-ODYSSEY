using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy_PrimeEdu.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int InstallationId { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Display(Name = "Course Description")]
        public string? Description { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; } //Values: "Online" or "Physical Location String"

        [Display(Name = "Duration (Hours)")]
        public int? CourseDuration { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name="Teacher")]
        public string? TeacherName { get; set; }

        //[Display(Name = "Enrolled Students")]
        public int? StudentCount { get; set; }
               

        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        /*
         * 1 teacher + n students [] 
         */

        public string? Logo { get; set; } //--UNUSED

        //RLs
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }        
        public int SelectedValue { get; set; }

        public List<Teacher>? TeacherNames { get; set; }

        public List <Course_Student>? Course_Students { get; set; } 
        public List<Course_Test>? Course_Tests { get; set; }
    }
}
