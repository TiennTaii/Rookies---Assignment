using assignment_one.Models;
using assignment_one.DTOs;

namespace StudentManagement.Services;

public interface IStudentService
{
    // IEnumerable<StudentViewModel> GetAll();
    // StudentViewModel? GetById(int id);
    // int? Create(StudentCreateModel createModel);
    // StudentViewModel? Update(int id, StudentUpdateModel updateModel);
    // bool Delete(int id);

    AddStudentResponse Create(AddStudentRequest createModel);
    IEnumerable<Student> GetAll();
    bool Delete(int id);
    UpdateRespone Update(int id, UpdateRequest updateRequest);

}