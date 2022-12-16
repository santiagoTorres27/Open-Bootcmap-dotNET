using Ejercicio3.DataModels;

namespace Ejercicio3.Services
{
    class Services
    {
        public IEnumerable<User> GetUsersByEmail(List<User> users, string email)
        {
            // method 1
            var usersResult = from user in users
                              where user.Email.ToLower().Contains(email)
                              select user;

            // method 2
            var list = users.Where(user => user.Email.Contains(email));
            return list;
        }

        public IEnumerable<Student> GetLegalAgeStudents(List<Student> students)
        {
            // method 1
            var resultList = from student in students
                             where student.GetAge() >= 18
                             select student;

            // method 2
            var list = students.Where(student => student.GetAge() > 18);
            return list;
        }

        public IEnumerable<Student> GetStudentsWithCourses(List<Student> students)
        {
            // method 1
            var resultList = from student in students
                             where student.Courses.Any()
                             select student;

            // method 2
            var list = students.Where(student => student.Courses.Any());
            return list;
        }

        public IEnumerable<Course> GetCoursesOfCertainLevelWithStudents(List<Course> courses, Level level)
        {
            var resultList = from course in courses
                             where course.Level == level
                             && course.Students.Any()
                             select course;
            return resultList;
        }

        public IEnumerable<Course> GetCoursesWithCertainLevelAndCategory(List<Course> courses, Level level, int category)
        {
            var resultList = from course in courses
                             where course.Level.Equals(level)
                             && course.Categories.Any(cat => cat.Equals(category))
                             select course;
            return resultList;
        }

        public IEnumerable<Course> GetCoursesWithoutStudents(List<Course> courses)
        {
            var resultList = from course in courses
                             where course.Students.Count() == 0
                             select course;

            var list = courses.Where(c => c.Students.Any());
            return list;
        }
    }
}
