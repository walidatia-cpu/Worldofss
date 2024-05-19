using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Manager.Core.Entities
{
    public class CV
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(PersonalInformation))]
        public int Personal_Information_Id { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }

        [ForeignKey(nameof(ExperienceInformation))]
        public int Experience_Information_Id { get; set; }
        public virtual ExperienceInformation ExperienceInformation { get; set; }

    }
}
