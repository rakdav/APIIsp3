using Microsoft.EntityFrameworkCore;

namespace APIIsp3.Models
{
    public class ModelDB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public ModelDB(DbContextOptions<ModelDB> options):
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}
