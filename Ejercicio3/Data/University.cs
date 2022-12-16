using Ejercicio3.DataModels;

namespace Ejercicio3.Data
{
    class University
    {
        public List<User> Users { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

        public University()
        {
            // Users
            Users = new List<User>()
            {
                new User("Santiago", "Torres", "santiago@gmail.com", "12345"),
                new User("Carla", "Rodriguez", "carla@gmail.com", "12345"),
                new User("Sergio", "Fernandez", "sergio@gmail.com", "12345"),
            };

            // Courses
            Courses = new List<Course>()
            {
                new Course("Programacion", "", "clase de programacion", Level.Hard, new List<int> { 1, 2, 3}, new List<int> {1, 2, 3}),
                new Course("Base de datos", "", "clase de bbdd", Level.Expert, new List<int> { }, new List<int> {1}),
                new Course("HTML", "", "clase de html", Level.Expert, new List<int> { 1}, new List<int> (){}),
                new Course("CSS", "", "clase de CSS", Level.Hard, new List<int> { 1}, new List<int> ()),
            };


            // Students
            Students = new List<Student>()
            {
                new Student("Juana", "Martinez", new DateTime(1992, 12, 12), new List<int>(){1, 2}),
                new Student("Alejandra", "García", new DateTime(2006, 12, 12), new List<int>()),
                new Student("Rodrigo", "López", new DateTime(2010, 12, 12), new List<int>() {1}),
                new Student("Carmen", "García", new DateTime(1992, 10, 12), new List<int>(){1, 2, 3}),

            };
        }
    }
}
