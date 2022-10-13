using Assignment_three.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_three.Controllers
{
    public class RookiesController : Controller
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

        public readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonCreateModel model)
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                BirthPlace = model.BirthPlace,
                PhoneNumber = model.PhoneNumber,
                IsGraduated = false
            };
            _people.Add(person);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                var model = new PersonUpdateModel
                {
                    LastName = person.LastName,
                    FirstName = person.FirstName,
                    Gender = person.Gender,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber
                };
                ViewData["Index"] = index;

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int index, PersonUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                if (index >= 0 && index < _people.Count)
                {
                    var person = _people[index];
                    person.LastName = model.LastName;
                    person.FirstName = model.FirstName;
                    person.Gender = model.Gender;
                    person.BirthPlace = model.BirthPlace;
                    person.PhoneNumber = model.PhoneNumber;
                };
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                _people.RemoveAt(index);
            };
            return RedirectToAction("Index");
        }
    }
}