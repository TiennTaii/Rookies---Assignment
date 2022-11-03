namespace Assignment_one.Models
{
    public class PersonDetailsModel
    {
        public Guid Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }

        public string FullName
        {
            get
            {
                var FullName = LastName + " " + FirstName;
                return FullName;
            }
        }
    }
}