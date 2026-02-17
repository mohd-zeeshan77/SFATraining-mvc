using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTestMVC.Models;

public sealed class CityViewModel
{
    public int Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required][ForeignKey("State")] public int? StateId { get; set; }

    public IEnumerable<StateViewModel>? States { get; set; }
}