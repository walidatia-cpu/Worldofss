using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Command
{
    public class Update_PersonalInformation_VM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string? CityName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required, RegularExpression("^[0-9]*$", ErrorMessage = "Mobile number must contain only digits.")]
        public string MobileNumber { get; set; }
    }
}
