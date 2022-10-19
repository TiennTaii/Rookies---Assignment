using EntityFrameworkCore_Day1.DTOs;
using assignment_one.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public AddStudentResponse Create(AddStudentRequest createModel)
    {
        var createStudent = new Student
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            City = createModel.City,
            State = createModel.State
        };

        var student = _studentRepository.Create(createStudent);

        _studentRepository.SaveChanges();

        return new AddStudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName
        };
    }
}