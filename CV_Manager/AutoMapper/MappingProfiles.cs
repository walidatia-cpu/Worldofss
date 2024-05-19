using AutoMapper;
using CV_Manager.Core.Dto.CV_Modules;
using CV_Manager.Core.Entities;
using CV_Manager.Core.ViewModel.CV_Modules.Command;

namespace CV_Manager.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Remember
            // CreateMap<SourceClass, DestinationClass>();
            #endregion

            #region CV Manager
            _Create_CV_CommandMap();
            _Update_CV_CommandMap();
            _Get_CV_Dto();

            #endregion
        }
        void _Create_CV_CommandMap()
        {
            CreateMap<Create_CV_VM, CV>();
            CreateMap<Create_ExperienceInformation_VM, ExperienceInformation>();
            CreateMap<Create_PersonalInformation_VM, PersonalInformation>();
        }
        void _Update_CV_CommandMap()
        {
            CreateMap<Update_CV_VM, CV>();
            CreateMap<Update_ExperienceInformation_VM, ExperienceInformation>();
            CreateMap<Update_PersonalInformation_VM, PersonalInformation>();
        }
        void _Get_CV_Dto()
        {
            CreateMap<CV, CV_Dto>();
            CreateMap<ExperienceInformation, ExperienceInformation_Dto>();
            CreateMap<PersonalInformation, PersonalInformation_Dto>();
        }
    }
}
