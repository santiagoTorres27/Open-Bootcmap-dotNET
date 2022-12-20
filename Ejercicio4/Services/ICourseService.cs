using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCoursesByCategory(int courseId);
        IEnumerable<Course> GetCoursesWithoutChapters();
        IEnumerable<Course> GetCourseChapter(int courseId);
        IEnumerable<Course> GetCoursesByStudent(int studentId);

    }
}
