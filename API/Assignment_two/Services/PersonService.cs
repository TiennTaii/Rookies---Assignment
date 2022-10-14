using Assignment_one.Models;

namespace Assignment_one.Services
{
    public class PersonService : IPersonService
    {
        public static List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel
            {
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
                FirstName = "Dung",
                LastName = "Do Trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 08, 21),
                PhoneNumber = "0456821337",
                BirthPlace = "Phu Tho",
                IsGraduated = true
            }
        };

        public List<PersonModel> GetAll()
        {
            return _people;
        }

        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                return _people[index];
            }
            return null;
        }

        public PersonModel Create(PersonModel model)
        {
            _people.Add(model);

            return model;
        }

        public PersonModel? Update(int index, PersonModel model)
        {
            if (index >= 0 && index < _people.Count)
            {
                _people[index] = model;

                return model;
            }
            return null;
        }

        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                _people.RemoveAt(index);

                return person;
            }
            return null;
        }
    }
}