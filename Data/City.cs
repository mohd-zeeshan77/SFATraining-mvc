using System.ComponentModel.DataAnnotations;

namespace WebTestMVC.Data
{
    public class City
    {
        [Key]public int Id { get; set; }
        public string Name { get; set; }
        public int StateId {  get; set; }
    }
}
