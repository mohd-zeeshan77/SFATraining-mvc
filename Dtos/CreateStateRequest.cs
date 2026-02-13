using System.ComponentModel.DataAnnotations;

namespace WebTestMVC.Dtos;

public class CreateStateRequest(string Name, string Code, bool IsActive)
{
    [Required] public string Name { get; } = Name;

    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string Code { get; } = Code;

    public bool IsActive { get; } = IsActive;
}