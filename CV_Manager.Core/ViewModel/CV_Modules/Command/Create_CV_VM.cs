using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Command
{
    public class Create_CV_VM
    {
        [Required]
        public string Name { get; set; }
        public Create_PersonalInformation_VM PersonalInformation { get; set; }
        public Create_ExperienceInformation_VM ExperienceInformation { get; set; }
    }
}
