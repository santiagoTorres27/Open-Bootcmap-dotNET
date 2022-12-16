using Ejercicio3.Data;
using Ejercicio3.DataModels;
using Ejercicio3.Services;

class Program
{
    static void Main()
    {
        University data = new University();
        Services services = new Services();

        var result = services.GetUsersByEmail(data.Users, "ca");

        var legalAgeStudents = services.GetLegalAgeStudents(data.Students);

        var studentsWithCourses = services.GetStudentsWithCourses(data.Students);

        var coursesCertainLevelWithStudents = services.GetCoursesOfCertainLevelWithStudents(data.Courses, Level.Expert);

        var courses = services.GetCoursesWithCertainLevelAndCategory(data.Courses, Level.Expert, 1);

        var coursesWithoutStudents = services.GetCoursesWithoutStudents(data.Courses);

        // Print list
        foreach (var item in coursesCertainLevelWithStudents)
        {
            Console.WriteLine(item);
        }

    }
}