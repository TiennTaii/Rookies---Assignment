using assignment_one.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_one.Data
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
    }
}