using System.ComponentModel.DataAnnotations;

namespace Ejercicio1.Models
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
