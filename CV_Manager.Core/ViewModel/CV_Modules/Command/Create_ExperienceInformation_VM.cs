using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Command
{
    public class Create_ExperienceInformation_VM
    {
        [Required, MaxLength(20)]
        public string CompanyName { get; set; }
        public string? City { get; set; }
        public string? CompanyField { get; set; }
    }
}
