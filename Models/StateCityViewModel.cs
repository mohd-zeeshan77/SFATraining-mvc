using System.ComponentModel.DataAnnotations;

namespace WebTestMVC.Models
{
    public sealed class StateCityViewModel
    {
        [Required]
        public string CityName { get; init; }
        [Required]
        public string StateName { get; init; }
        [Required]
        [StringLength (maximumLength:2, MinimumLength =2)]
        public string StateCode {  get; init; }
    }
}
