using Microsoft.AspNetCore.Mvc;

namespace assignment_two.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{


    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

}
