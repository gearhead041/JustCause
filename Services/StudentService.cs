using AutoMapper;
using JustCause.Data;
using JustCause.Dtos;
using JustCause.Models;
using JustCause.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JustCause.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public StudentService(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<StudentDto?> CreateStudent(StudentDto studentDto)
    {
        var studentToSave = mapper.Map<StudentRegistrationInfo>(studentDto);
        context!.StudentRegistrations!.Add(studentToSave);
        await context.SaveChangesAsync();
        mapper.Map(studentToSave, studentDto);
        return studentDto;
    }

    public async Task DeleteStudent(int studentId)
    {
        var student = await context!.StudentRegistrations!
            .SingleOrDefaultAsync(s => s.Id == studentId);
        if (student == null)
            return;
        context!.StudentRegistrations!.Remove(student);
    }

    public async Task<IEnumerable<StudentDto>?> GetAllStudents()
    {
        var studentsFromDb = await context!.StudentRegistrations!.ToListAsync();
        var studentsToReturn = mapper.Map<IEnumerable<StudentDto>>(studentsFromDb);
        foreach (var student in studentsToReturn)
        {
            var practical = await context!.Practicals!.SingleOrDefaultAsync(p => p.Id == student.PracticalId);
            var practicalDto = mapper.Map<PracticalDto>(practical);
            student.Practical = practicalDto;
        }
        return studentsToReturn;
    }

    public async Task<StudentDto?> GetStudent(int studentId)
    {
        var student = await context!.StudentRegistrations!
        .Include(s => s.Practical)
        .SingleOrDefaultAsync(s => s.Id == studentId);
        var studentToReturn = mapper.Map<StudentDto>(student);
        if (student != null)
            return studentToReturn;
        return null;
    }
}
