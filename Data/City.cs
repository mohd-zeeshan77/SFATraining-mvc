using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTestMVC.Data
{
    [Table("city")]
    public sealed class City
    {
        [Column("id")]
        [Key]public int Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [ForeignKey("State")]
        public int StateId {  get; set; }

        public State? State { get; set; }
    }
}
