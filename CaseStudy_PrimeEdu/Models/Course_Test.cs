using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Models
{
    public class Course_Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InstallationId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
