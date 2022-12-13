using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class User : BaseEntity
    {
        [Required, StringLength(150)]
        public string? Name { get; set; }

        [Required, StringLength(100)]
        public string? LastName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }


    }
}
