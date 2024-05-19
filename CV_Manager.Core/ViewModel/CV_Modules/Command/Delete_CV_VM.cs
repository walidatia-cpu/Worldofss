using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Command
{
    public class Delete_CV_VM
    {
        [Required]
        public int Id { get; set; }
    }
}
