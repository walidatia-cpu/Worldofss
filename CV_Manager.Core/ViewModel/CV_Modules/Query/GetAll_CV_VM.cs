using System.ComponentModel.DataAnnotations;

namespace CV_Manager.Core.ViewModel.CV_Modules.Query
{
    public class GetAll_CV_VM
    {
        [Required]
        public int Page { get; set; } = 1;
        [Required]
        public int PageCount { get; set; } = 10;
    }
}
