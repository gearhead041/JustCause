using System.ComponentModel.DataAnnotations;

namespace JustCause.Dtos;

public class PracticalDto
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Range(1,3000,ErrorMessage ="Size must be greater than 0")]
    public int MaxSize { get; set; }

    public ICollection<StudentDto>? StudentRegistrations { get; set; }
}