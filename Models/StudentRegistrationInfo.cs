using System.ComponentModel.DataAnnotations;

namespace JustCause.Models;
public class StudentRegistrationInfo
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? MatricNumber { get; set; }
    [Required]
    public string? Level { get; set;}
    [Required]
    public Practical? Practical { get; set; }
    public int PracticalId { get;  set;}
}