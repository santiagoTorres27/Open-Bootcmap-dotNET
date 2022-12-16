namespace Ejercicio3.DataModels
{
    public enum Level
    {
        Basic,
        Medium,
        Hard,
        Expert
    }

    class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Level Level { get; set; } = Level.Basic;
        public List<int> Categories { get; set; }
        public List<int> Students { get; set; }
        //public Chapter Chapter { get; set; } = new Chapter();

        public Course(string name, string shortDescription, string description, Level level, List<int> categories, List<int> students)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Level = level;
            Categories = categories;
            Students = students;
        }

        public override string? ToString()
        {
            return $"{Name} - {Description} - {Level} - Students:";
        }


    }


}
