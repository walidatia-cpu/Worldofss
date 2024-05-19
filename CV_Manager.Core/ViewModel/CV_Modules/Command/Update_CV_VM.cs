using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Command
{
    public class Update_CV_VM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Update_PersonalInformation_VM PersonalInformation { get; set; }
        public Update_ExperienceInformation_VM ExperienceInformation { get; set; }
    }
}
