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

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok(_task);
    }

    [HttpPost("{id}")]
    public IActionResult Get(string id)
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

    [HttpDelete("{id}")]
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

    // [HttpPost("bulk")]
    // public IActionResult CreateBulkTask(List<NewTaskRequestModel> requestModel)
    // {
    //     foreach (var item in requestModel)
    //     {
    //         CreateBulkTask(requestModel);
    //     }

    //     return Task.CompletedTask;
    // }

    // private void CreateBulkTask_Service(NewTaskRequestModel requestModel)
    // {
    //     System.Threading.Thread.Sleep(10);
    // }

    // private
}
