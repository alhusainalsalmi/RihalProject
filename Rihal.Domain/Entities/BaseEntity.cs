
using System.ComponentModel.DataAnnotations.Schema;

namespace Rihal.Domain.Entities
{
    public class BaseEntity
    {
        [Column("creation_date")]
        public DateTime CreationDate { get; set; } 
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; } 
    }
}
