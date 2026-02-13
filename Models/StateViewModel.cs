using System.ComponentModel.DataAnnotations;

namespace WebTestMVC.Models;

public sealed class StateViewModel
{
    public required int Id { get; init; }

    [Required] public required string Name { get; init; }

    [Required]
    [StringLength(2, MinimumLength = 2)]
    public required string Code { get; init; }

    public required bool IsActive { get; init; }
}