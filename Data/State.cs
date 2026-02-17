using System.ComponentModel.DataAnnotations.Schema;

namespace WebTestMVC.Data;

[Table("state")]
public sealed class State
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Code { get; set; }
    public required bool IsActive { get; set; }
}