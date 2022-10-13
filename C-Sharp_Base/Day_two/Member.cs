using System;

namespace Day_1
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public string Graduated { get; set; }
        public uint Age { get { return (uint)(DateTime.Now.Year - DateOfBirth.Year); } }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Gender + " " + this.DateOfBirth + " " +
             this.PhoneNumber + " " + this.BirthPlace + " " + this.Graduated;
        }

        public string FullName
        {
            get
            {
                var FullName = FirstName + " " + LastName;
                return FullName;
            }
        }
    }
}
