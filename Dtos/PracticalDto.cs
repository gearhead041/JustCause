using System.ComponentModel.DataAnnotations;

namespace JustCause.Dtos;

public class PracticalDto
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public int MaxSize { get; set; }

    public ICollection<StudentDto>? StudentRegistrations { get; set; }
}