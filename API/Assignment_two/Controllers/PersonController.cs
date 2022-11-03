using Assignment_one.Models;
using Assignment_one.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_one.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    [Route("all-list")]
    public IEnumerable<PersonDetailsModel> GetAll()
    {
        var data = _personService.GetAll();

        return from item in data
               select new PersonDetailsModel
               {
                   Id = item.Id,
                   FirstName = item.FirstName,
                   LastName = item.LastName,
                   Gender = item.Gender,
                   DateOfBirth = item.DateOfBirth,
                   PhoneNumber = item.PhoneNumber,
                   BirthPlace = item.BirthPlace
               };
    }

    [HttpGet]
    [Route("get-{id:Guid}")]
    public IActionResult? GetOne(Guid id)
    {
        try
        {
            var data = _personService.GetOne(id);
            if (data == null)
            {
                return NotFound();
            }

            return new JsonResult(new PersonDetailsModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Gender = data.Gender,
                DateOfBirth = data.DateOfBirth,
                PhoneNumber = data.PhoneNumber,
                BirthPlace = data.BirthPlace
            });
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Create(PersonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                BirthPlace = model.BirthPlace,
                IsGraduated = false
            };
            var result = _personService.Create(person);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut]
    [Route("update-{id:Guid}")]
    public IActionResult Update(Guid id, PersonUpdateModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var data = _personService.GetOne(id);

            if (data == null)
            {
                return NotFound();
            }

            {
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Gender = model.Gender;
                data.DateOfBirth = model.DateOfBirth;
                data.PhoneNumber = model.PhoneNumber;
                data.BirthPlace = model.BirthPlace;

                var result = _personService.Update(id, data);

                return new JsonResult(result);
            }
        }

        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete]
    [Route("delete-{id:Guid}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            var data = _personService.GetOne(id);

            if (data == null)
            {
                return NotFound();
            }

            var result = _personService.Delete(id);

            return new JsonResult(result);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet]
    [Route("search")]
    public List<PersonModel> GetFilterList(string fullName)
    {
        return _personService.FilterName(fullName);
    }
}