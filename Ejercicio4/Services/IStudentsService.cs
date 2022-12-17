using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithoutCourses();

        IEnumerable<Student> GetStudentsByCourse(int courseId);
    }
}
