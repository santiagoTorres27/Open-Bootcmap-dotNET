using Microsoft.Build.Framework;

namespace UniversityApiBackend.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirthday { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
