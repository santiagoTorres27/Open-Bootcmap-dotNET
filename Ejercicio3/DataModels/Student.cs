namespace Ejercicio3.DataModels
{
    class Student : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; }
        public List<int> Courses { get; set; }

        public Student(string firstName, string lastName, DateTime dateOfBirthday, List<int> courses)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;
            Courses = courses;
        }

        public int GetAge()
        {
            TimeSpan age = DateTime.Now - DateOfBirthday;
            return new DateTime(age.Ticks).Year - 1;
        }


        public override string? ToString()
        {
            return $"{FirstName} {LastName} - {GetAge()}";
        }
    }
}
