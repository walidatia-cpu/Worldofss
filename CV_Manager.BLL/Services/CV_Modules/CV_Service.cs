using AutoMapper;
using CV_Manager.Core.Constant;
using CV_Manager.Core.Contracts;
using CV_Manager.Core.Contracts.CV_Modules;
using CV_Manager.Core.Dto;
using CV_Manager.Core.Dto.CV_Modules;
using CV_Manager.Core.Entities;
using CV_Manager.Core.ViewModel.CV_Modules.Command;
using CV_Manager.Core.ViewModel.CV_Modules.Query;

namespace CV_Manager.BLL.Services.CV_Modules
{
    public class CV_Service : ICV_Service
    {
        #region fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository<CV> cvRepository;
        private readonly IMapper mapper;
        #endregion

        #region ctor
        public CV_Service(IUnitOfWork unitOfWork, IAsyncRepository<CV> cvRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.cvRepository = cvRepository;
            this.mapper = mapper;
        }
        #endregion

        #region methods
        public async Task<CommonResponse<CV_Dto>> Create(Create_CV_VM _VM)
        {
            try
            {
                #region Begin Transaction
                await _unitOfWork.BeginTransactionAsync();
                #endregion

                #region Create
                var _cv = mapper.Map<CV>(_VM);
                await cvRepository.AddAsync(_cv);
                #endregion

                #region Save Changes
                await _unitOfWork.CommitAsync();
                #endregion

                #region Response
                var _data = mapper.Map<CV_Dto>(_cv);
                return new CommonResponse<CV_Dto>() { Data = _data, RequestStatus = RequestStatus.Success, Message = "Added successfully" };
                #endregion
            }
            catch (Exception ex)
            {
                #region Response
                await _unitOfWork.RollbackAsync();
                // Handle exception : log exception
                return new CommonResponse<CV_Dto>() { Data = new CV_Dto(), RequestStatus = RequestStatus.ServerError, Message = "SERVER_ERROR" };
                #endregion
            }

        }

        public async Task<CommonResponse<object>> Delete(Delete_CV_VM _VM)
        {
            try
            {

                #region Validation
                var _cv = await cvRepository.FirstOrDefaultAsync(c => c.Id == _VM.Id);
                if (_cv is null)
                    return new CommonResponse<object>() { Data = new object(), RequestStatus = RequestStatus.BadRequest, Message = "CV Not Found" };
                #endregion

                #region Remove 
                await cvRepository.RemoveAsync(_cv);
                await _unitOfWork.SaveChangesAsync();
                #endregion

                #region Response
                return new CommonResponse<object>() { Data = new object(), RequestStatus = RequestStatus.Success, Message = "Deleted successfully" };
                #endregion
            }
            catch (Exception ex)
            {
                // Handle exception : log exception
                #region Response
                return new CommonResponse<object>() { Data = new object(), RequestStatus = RequestStatus.ServerError, Message = "SERVER_ERROR" };
                #endregion
            }
        }

        public async Task<CommonResponse<List<CV_Dto>>> GetAll(GetAll_CV_VM _VM)
        {
            try
            {
                var _cvs = await cvRepository.GetAllAsync(_VM.Page, _VM.PageCount);

                #region Response
                return new CommonResponse<List<CV_Dto>> { RequestStatus = RequestStatus.Success, Message = "Success", Data = mapper.Map<List<CV_Dto>>(_cvs) };
                #endregion

            }
            catch (Exception ex)
            {
                // Handle exception : log exception
                #region Response
                return new CommonResponse<List<CV_Dto>>() { Data = new List<CV_Dto>(), RequestStatus = RequestStatus.ServerError, Message = "SERVER_ERROR" };
                #endregion
            }
        }

        public async Task<CommonResponse<CV_Dto>> Update(Update_CV_VM _VM)
        {
            try
            {
                #region Validation
                var _cv = await cvRepository.FirstOrDefaultAsync(c => c.Id == _VM.Id);
                if (_cv is null)
                    return new CommonResponse<CV_Dto>() { Data = new CV_Dto(), RequestStatus = RequestStatus.BadRequest, Message = "CV Not Found" };
                #endregion

                #region Begin Transaction
                await _unitOfWork.BeginTransactionAsync();
                #endregion

                #region update
                _cv = mapper.Map(_VM, _cv);
                await cvRepository.UpdateAsync(_cv);
                #endregion

                #region Save Changes
                await _unitOfWork.CommitAsync();
                #endregion

                #region Response
                var _data = mapper.Map<CV_Dto>(_cv);
                return new CommonResponse<CV_Dto>() { Data = _data, RequestStatus = RequestStatus.Success, Message = "Updated successfully" };
                #endregion
            }
            catch (Exception ex)
            {
                #region Response
                await _unitOfWork.RollbackAsync();
                // Handle exception : log exception
                return new CommonResponse<CV_Dto>() { Data = new CV_Dto(), RequestStatus = RequestStatus.ServerError, Message = "SERVER_ERROR" };
                #endregion
            }
        }

        #endregion
    }

}
