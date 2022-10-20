using assignment_one.Models;
using assignment_one.DTOs;
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

    [HttpGet]
    public IEnumerable<Student>? GetAll()
    {
        try
        {
            var student = _studentService.GetAll();

            return student;
        }
        catch (Exception)
        {
            return null;
        }
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        var student = _studentService.Delete(id);

        return student;
    }

    [HttpPut("update")]
    public UpdateRespone Update(int id, UpdateRequest updateRequest)
    {
        return _studentService.Update(id, updateRequest);
    }
}