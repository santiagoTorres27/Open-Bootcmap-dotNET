using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CourseService : ICourseService
    {
        public IEnumerable<Course> GetCoursesByCategory(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesWithoutChapters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCourseChapter(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByStudent(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
