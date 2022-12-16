namespace Ejercicio3.DataModels
{
    class Category
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
