using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }

        [Required]
        public Course Course { get; set; } = new Course();

        [Required]
        public string ChapterList { get; set; }
    }
}
