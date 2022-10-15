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
            var newID = 1;
            return Ok(newID);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
