using assignment_one.DTOs;
using assignment_one.Models;
using StudentManagement.Repositories;
using StudentManagement.Models;

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

    public bool Delete(int id)
    {
        var student = _studentRepository.Get(x => x.Id == id);

        if (student == null)
        {
            return false;
        }
        _studentRepository.Delete(student);

        _studentRepository.SaveChanges();

        return true;
    }

    public IEnumerable<Student> GetAll()
    {
        var students = _studentRepository.GetAll(x => true);

        return students;
    }

    public UpdateRespone Update(int id, UpdateRequest updateRequest)
    {
        var student = _studentRepository.Get(x => x.Id == id);

        if (student == null) return null;

        student.FirstName = updateRequest.FirstName;
        student.LastName = updateRequest.LastName;
        student.City = updateRequest.City;
        student.State = updateRequest.State;

        student = _studentRepository.Update(student);

        _studentRepository.SaveChanges();

        return new UpdateRespone
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            City = student.City,
            State = student.State
        };
    }
}