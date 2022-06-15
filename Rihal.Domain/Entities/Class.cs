
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rihal.Domain.Entities
{
    [Table("classes")]
    public class Class : BaseEntity
    {
        [Key]
        [Column("id")]
        public int ClassId { get; set; }
        [Column("class_name")]
        public string Name { get; set; } 
        public ICollection<Student> Students { get; set; }
    }
}
