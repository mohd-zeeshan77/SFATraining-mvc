using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTestMVC.Data;

[Table("state")]
public sealed class State
{
    [Column("id")] [Key] public int Id { get; set; }

    [Column("name")] [StringLength(100)] public required string Name { get; set; }

    [Column("code")] [StringLength(2)] public required string Code { get; set; }
    public required bool IsActive { get; set; }
}