using System.ComponentModel.DataAnnotations;

namespace JustCause.Models;

public class Practical
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public int MaxSize { get; set; }
    public ICollection<StudentRegistrationInfo>? StudentRegistrations { get; set; }
}
