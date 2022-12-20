using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CourseService : ICourseService
    {

        private readonly UniversityDBContext _context;

        public CourseService(UniversityDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategory(int courseId)
        {
            //throw new NotImplementedException();
            return await _context.Courses.Where(course => course.Id == courseId).ToListAsync();
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

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
