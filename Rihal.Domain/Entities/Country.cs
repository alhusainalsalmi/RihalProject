using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rihal.Domain.Entities
{
    [Table("countries")]
    public class Country : BaseEntity
    {
        [Key]
        [Column("id")]
        public int CountryId { get; set; }
        [Column("name")]
        public string Name { get; set; } 
        public ICollection<Student> Students { get; set; }

    }
}
