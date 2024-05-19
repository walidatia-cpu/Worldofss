using CV_Manager.Core.Dto;
using CV_Manager.Core.Dto.CV_Modules;
using CV_Manager.Core.ViewModel.CV_Modules.Command;
using CV_Manager.Core.ViewModel.CV_Modules.Query;

namespace CV_Manager.Core.Contracts.CV_Modules
{
    public interface ICV_Service
    {
        Task<CommonResponse<CV_Dto>> Create(Create_CV_VM _VM);
        Task<CommonResponse<CV_Dto>> Update(Update_CV_VM _VM);
        Task<CommonResponse<object>> Delete(Delete_CV_VM _VM);
        Task<CommonResponse<List<CV_Dto>>> GetAll(GetAll_CV_VM _VM);
    }
}
