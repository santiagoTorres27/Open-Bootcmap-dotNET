namespace Ejercicio8.DTO
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }
    }

    public class ProductV2
    {
        public int id { get; set; }
        public Guid guid { get; set; } = Guid.NewGuid();
        public string title { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }
    }

    public class Rating
    {
        public float rate { get; set; }
        public long count { get; set; }
    }

}
