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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassList>()
                .HasKey(cl => new { cl.PersonID, cl.ClassID });

            // Many-to-many relationships

            // Person to ClassList
            modelBuilder.Entity<ClassList>()
                .HasOne(cl => cl.Person)
                .WithMany(cl => cl.ClassLists)
                .HasForeignKey(cl => cl.PersonID);

            // Class to ClassList
            modelBuilder.Entity<ClassList>()
                .HasOne(cl => cl.Class)
                .WithMany(cl => cl.ClassLists)
                .HasForeignKey(cl => cl.ClassID);
        }
    }
}
