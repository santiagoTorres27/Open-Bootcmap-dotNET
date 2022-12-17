using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {
        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithoutCourses()
        {
            throw new NotImplementedException();
        }
    }
}
