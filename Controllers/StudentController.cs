using JustCause.Dtos;
using JustCause.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JustCause.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
	private readonly IServiceManager serviceManager;

	public StudentsController(IServiceManager serviceManager)
	{
		this.serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<ActionResult<List<StudentDto>>> GetAllStudents()
	{
		var students = await serviceManager.StudentService.GetAllStudents();
		return Ok(students);
	}

	[HttpGet("{id:int}", Name = "GetStudentById")]
	public async Task<ActionResult<StudentDto>> GetStudent(int id)
	{
		var student = await serviceManager.StudentService.GetStudent(id);
        if (student == null)
			return NotFound();
		return Ok(student);
	}

	//[Authorize]
	[HttpPost]
	public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto student)
	{
		var studentToReturn = await serviceManager.StudentService.CreateStudent(student);
		return CreatedAtRoute("GetStudentById",new {id = studentToReturn!.Id},studentToReturn);
	}
}
