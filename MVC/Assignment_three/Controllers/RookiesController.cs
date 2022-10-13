using Assignment_three.Models;
using Assignment_three.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_three.Controllers
{
    public class RookiesController : Controller
    {


        public readonly ILogger<RookiesController> _logger;
        public readonly IPersonService _personService;

        public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            var models = _personService.GetAll();

            return View(models);
        }

        public IActionResult Details(int index)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                var model = new PersonDetailsModel
                {
                    LastName = person.LastName,
                    FirstName = person.FirstName,
                    Gender = person.Gender,
                    DateOfBirth = person.DateOfBirth,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber
                };
                ViewData["Index"] = index;

                return View(model);
            }
            return View();
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
            _personService.Create(person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
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
                var person = _personService.GetOne(index);

                if (person != null)
                {
                    person.LastName = model.LastName;
                    person.FirstName = model.FirstName;
                    person.Gender = model.Gender;
                    person.BirthPlace = model.BirthPlace;
                    person.PhoneNumber = model.PhoneNumber;

                    _personService.Update(index, person);
                };
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            var result = _personService.Delete(index);

            if (result == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAndRedirectToResultView(int index)
        {
            var result = _personService.Delete(index);

            if (result == null)
            {
                return NotFound();
            }
            TempData["DeletedPersonName"] = result.FullName;

            return RedirectToAction("DeleteResult");
        }

        public IActionResult DeleteResult()
        {
            return View();
        }
    }
}