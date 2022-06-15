using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rihal.Domain.Entities
{
    [Table("students")]
    public class Student : BaseEntity
    {
        [Key]
        [Column("id")]
        public int StudentId { get; set; }
        [Column("name")]
        public string Name { get; set; } 
        [Column("class_Id")]
        public int ClassId { get; set; }
        [Column("country_Id")]
        public int CountryId { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        public Class Class { get; set; }
        public Country Country { get; set; }
    }
}
