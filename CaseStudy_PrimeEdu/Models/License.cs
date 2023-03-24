using System.ComponentModel.DataAnnotations;

namespace CaseStudy_PrimeEdu.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; } //This is referred as InstallationId to other entities
        public string CompanyName { get; set; }
        public bool Active { get; set; } 
    }
}
