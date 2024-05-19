namespace CV_Manager.Core.Entities
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? CityName { get; set; }
        public string? Email { get; set; }
        public string MobileNumber { get; set; }
        public virtual CV CV { get; set; }
    }

}
