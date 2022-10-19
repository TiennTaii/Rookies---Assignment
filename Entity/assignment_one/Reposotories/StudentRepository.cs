using assignment_one.Data;
using assignment_one.Models;
using StudentManagement.Repositories;

namespace assignment_one.Services
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentManagementContext context) : base(context)
        {
        }
    }
};