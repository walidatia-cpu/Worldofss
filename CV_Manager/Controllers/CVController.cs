using CV_Manager.Core.Contracts.CV_Modules;
using CV_Manager.Core.Dto;
using CV_Manager.Core.Dto.CV_Modules;
using CV_Manager.Core.ViewModel.CV_Modules.Command;
using CV_Manager.Core.ViewModel.CV_Modules.Query;
using CV_Manager.Filters.ActionFilter;
using Microsoft.AspNetCore.Mvc;

namespace CV_Manager.Controllers
{
    [Route("api/v1/CV")]
    [ApiController]
    public class CVController : ControllerBase
    {
        #region fields
        private readonly ICV_Service cV_Service;
        #endregion

        #region ctor
        public CVController(ICV_Service cV_Service)
        {
            this.cV_Service = cV_Service;
        }
        #endregion

        #region methods

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Route("CreateCV")]
        public async Task<CommonResponse<CV_Dto>> CreateCV([FromBody] Create_CV_VM model)
        {
            return await cV_Service.Create(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Route("UpdateCV")]
        public async Task<CommonResponse<CV_Dto>> UpdateCV([FromBody] Update_CV_VM model)
        {
            return await cV_Service.Update(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Route("DeleteCV")]
        public async Task<CommonResponse<object>> DeleteCV([FromBody] Delete_CV_VM model)
        {
            return await cV_Service.Delete(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Route("GetAllCVs")]
        public async Task<CommonResponse<List<CV_Dto>>> GetAllCVs([FromBody] GetAll_CV_VM model)
        {
            return await cV_Service.GetAll(model);
        }

        #endregion
    }
}
