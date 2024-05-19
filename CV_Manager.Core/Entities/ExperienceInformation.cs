using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.Entities
{
    public class ExperienceInformation
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string CompanyName { get; set; }
        public string? City { get; set; }
        public string? CompanyField { get; set; }
        public virtual CV CV { get; set; }

    }
}
