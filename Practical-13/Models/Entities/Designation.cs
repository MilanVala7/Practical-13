using System.ComponentModel.DataAnnotations;

namespace Practical_13.Models.Entities
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DesignationName { get; set; }
    }
}