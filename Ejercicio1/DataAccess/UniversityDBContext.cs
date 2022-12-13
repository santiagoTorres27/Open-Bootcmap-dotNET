using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
