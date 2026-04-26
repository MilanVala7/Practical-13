using System;
using System.ComponentModel.DataAnnotations;

namespace Practical_13.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public int? Age { get; set; }
    }
}