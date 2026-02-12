using System.ComponentModel.DataAnnotations;

namespace WebTestMVC.Dtos
{
    public class CreateStateRequest
    {
        [Required]
        public required string Name { get; init; }
        [Required]
        [StringLength(2,MinimumLength =2)]
        public required string Code {  get; init; }
    }
}
