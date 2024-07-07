using Microsoft.EntityFrameworkCore;

using Server.Models;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ClassList> ClassLists { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
