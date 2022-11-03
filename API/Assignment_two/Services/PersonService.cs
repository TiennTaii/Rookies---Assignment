using Assignment_one.Models;


namespace Assignment_one.Services
{
    public class PersonService : IPersonService
    {
        public static List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Tai",
                LastName = "Pham Tien",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 03, 11),
                PhoneNumber = "0987678888",
                BirthPlace = "Vinh Phuc",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 02, 23),
                PhoneNumber = "0487348375",
                BirthPlace = "Ha Nam",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Lan",
                LastName = "Phan Thi",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 08, 13),
                PhoneNumber = "0328742341",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Tuyet",
                LastName = "Tran Thi",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 06, 13),
                PhoneNumber = "0238723836",
                BirthPlace = "Ha Nam",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Quyen",
                LastName = "Tran Thi",
                Gender = "Female",
                DateOfBirth = new DateTime(1999, 10, 27),
                PhoneNumber = "0888335263",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Long",
                LastName = "Nguyen Hai",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 07, 03),
                PhoneNumber = "0987678888",
                BirthPlace = "Quang Ninh",
                IsGraduated = false
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Tuan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 09, 29),
                PhoneNumber = "0329843271",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Minh",
                LastName = "Nguyen Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 26),
                PhoneNumber = "0239874231",
                BirthPlace = "Vinh Phuc",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Hoan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 10, 4),
                PhoneNumber = "0868477322",
                BirthPlace = "Bac Ninh",
                IsGraduated = false
            },
            new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Dung",
                LastName = "Do Trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 08, 21),
                PhoneNumber = "0456821337",
                BirthPlace = "Phu Tho",
                IsGraduated = true
            }
        };

        public PersonModel Create(PersonModel model)
        {
            throw new NotImplementedException();
        }

        public PersonModel? Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PersonModel> FilterName(string fullName)
        {
            throw new NotImplementedException();
        }

        public List<PersonModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonModel? GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public PersonModel? Update(Guid id, PersonModel model)
        {
            throw new NotImplementedException();
        }
    }
}