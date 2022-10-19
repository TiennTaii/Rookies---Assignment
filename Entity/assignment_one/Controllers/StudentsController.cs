using EntityFrameworkCore_Day1.DTOs;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Services;

namespace StudentManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public AddStudentResponse Add([FromBody] AddStudentRequest addRequest)
    {
        return _studentService.Create(addRequest);
    }

}