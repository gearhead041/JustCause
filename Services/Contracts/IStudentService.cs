using JustCause.Dtos;

namespace JustCause.Services.Contracts;

public interface IStudentService
{
    Task<StudentDto?> GetStudent(int studentId);
    Task<IEnumerable<StudentDto>?> GetAllStudents();
    Task<StudentDto?> CreateStudent(StudentDto studentDto);
    Task DeleteStudent(int studentId);
}
