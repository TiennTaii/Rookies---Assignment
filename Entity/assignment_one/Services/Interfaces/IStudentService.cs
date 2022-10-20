using assignment_one.Models;
using assignment_one.DTOs;

namespace StudentManagement.Services;

public interface IStudentService
{
    AddStudentResponse Create(AddStudentRequest createModel);
    IEnumerable<Student> GetAll();
    bool Delete(int id);
    UpdateRespone Update(int id, UpdateRequest updateRequest);

}