namespace CV_Manager.Core.Dto.CV_Modules
{
    public class CV_Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExperienceInformation_Dto ExperienceInformation { get; set; }
        public PersonalInformation_Dto PersonalInformation { get; set; }
    }
}
