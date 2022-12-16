namespace Ejercicio3.DataModels
{
    class Chapter : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public string ChapterList { get; set; }
    }
}
