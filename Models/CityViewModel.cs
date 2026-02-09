using System.ComponentModel.DataAnnotations;

namespace WebTestMVC.Models
{
    public sealed class CityViewModel
    {
        public required int Id { get; init; }
        [Required]
        public required string Name { get; init; }
        [Required]
        public required int StateId { get; init; }
        public IEnumerable<StateViewModel>? States { get; init; }
    }
}
