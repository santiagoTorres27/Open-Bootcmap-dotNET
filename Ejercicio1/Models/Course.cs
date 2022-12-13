using Ejercicio1.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio1.Models
{
    public class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [StringLength(280)]
        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        [Required]
        public string TargetAudience { get; set; }

        [Required]
        public string Objectives { get; set; }

        [Required]
        public string Requirements { get; set; }

        [Required]
        public Level CourseLevel { get; set; }


    }
}
