using Microsoft.EntityFrameworkCore;
using School.API.Domain;

namespace School.API.Database
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
