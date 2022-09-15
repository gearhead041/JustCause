using System.ComponentModel.DataAnnotations;

namespace JustCause.Dtos;

public class StudentDto
{
    public int Id { get; set; }

    [Required]
    [MinLength(5,ErrorMessage ="Enter a valid name")]
    public string? Name { get; set; }

    [Required]
    [RegularExpression(@"\d{2}[a-zA-Z]{2}\d\d\d\d\d\d",ErrorMessage ="Please enter a valid matric number")]
    public string? MatricNumber { get; set; }

    [Required]
    [RegularExpression("[3-5]00", ErrorMessage ="Enter a valid level 300-500")]
    public string? Level { get;set; }

    public int PracticalId { get; set; }

    public PracticalDto? Practical { get; set; }
}
