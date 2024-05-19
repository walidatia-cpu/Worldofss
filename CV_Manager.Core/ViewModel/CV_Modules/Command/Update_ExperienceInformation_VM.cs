using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Command
{
    public class Update_ExperienceInformation_VM
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string CompanyName { get; set; }
        public string? City { get; set; }
        public string? CompanyField { get; set; }
    }
}
