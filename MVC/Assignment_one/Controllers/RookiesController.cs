using Assignment_one.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_one.Controllers
{
    [Area("NashTech")]
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
            return Json(_people);
        }

        public IActionResult GetMaleMembers()
        {
            var data = _people.Where(p => p.Gender == "Male");

            return Json(data);
        }

        public IActionResult GetOldestMember()
        {
            var maxAge = _people.Max(p => p.Age);
            var oldest = _people.FirstOrDefault(p => p.Age == maxAge);

            return Json(oldest);
        }

        public IActionResult GetFullName()
        {
            var fullNames = _people.Select(p => p.FullName);

            return Json(fullNames);
        }

        public IActionResult GetMembersWhoBornIn2000()
        {
            var equals = _people.Where(p => p.DateOfBirth.Year == 2000);

            return Json(equals);
        }

        public IActionResult GetMembersWhoBornAfter2000()
        {
            var greaterThan = _people.Where(p => p.DateOfBirth.Year > 2000);

            return Json(greaterThan);
        }

        public IActionResult GetMembersWhoBornBefore2000()
        {
            var lessThan = _people.Where(p => p.DateOfBirth.Year < 2000);

            return Json(lessThan);
        }

        // export
        private byte[] WriteCsvToMemory(IEnumerable<PersonModel> people)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(people);
                streamWriter.Flush();

                return memoryStream.ToArray();
            }
        }

        public FileStreamResult Export()
        {
            var result = WriteCsvToMemory(_people);
            var memoryStream = new MemoryStream(result);

            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "people.csv" };
        }
    }
}