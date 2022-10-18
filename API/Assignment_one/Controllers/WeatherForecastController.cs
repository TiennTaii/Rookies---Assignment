using Assignment_one.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_one.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    public static List<NewTaskRequestModel> _task = new List<NewTaskRequestModel>
    {

    };

    [HttpPost("Create")]
    public IActionResult CreateNewTask(NewTaskRequestModel requestModel)
    {
        if (string.IsNullOrWhiteSpace(requestModel.Title))
        {
            return BadRequest("some message");
        }

        requestModel.Title = requestModel.Title.Trim();

        if (requestModel.Title.Length < 5 || requestModel.Title.Length > 20)
        {
            return BadRequest("some message");
        }

        try
        {
            var task = new NewTaskRequestModel
            {
                Id = Guid.NewGuid(),
                Title = requestModel.Title,
                IsCompleted = false
            };

            _task.Add(task);

            return Ok(_task);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        return Ok(_task);
    }

    [HttpPost("get-one")]
    public IActionResult GetOne(string id)
    {
        try
        {
            var getId = _task.SingleOrDefault(p => p.Id == Guid.Parse(id));

            if (getId == null)
            {
                return NotFound();
            }
            return Ok(getId);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("delete")]
    public IActionResult Delete(string id)
    {
        try
        {
            var deleteId = _task.SingleOrDefault(p => p.Id == Guid.Parse(id));

            if (deleteId == null)
            {
                return NotFound();
            }
            _task.Remove(deleteId);

            return Ok();
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("edit")]
    public IActionResult Edit(string id, NewTaskRequestModel model)
    {
        var getId = _task.SingleOrDefault(p => p.Id == Guid.Parse(id));

        if (getId != null)
        {
            getId.Title = model.Title;
            getId.IsCompleted = model.IsCompleted;

            return new JsonResult(getId);
        }

        return NotFound();
    }

    // [HttpPost("addBulk")]
    // public IActionResult AddBulk()
    // {
    //     var task = new NewsStyleUriParser
    //     {

    //     }
    // }


}