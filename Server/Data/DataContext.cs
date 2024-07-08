using Microsoft.EntityFrameworkCore;

using Server.Models;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<ClassList> ClassList => Set<ClassList>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the join table
            modelBuilder.Entity<ClassList>()
                .HasKey(cl => new { cl.PersonID, cl.ClassID });

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Classes)
                .WithMany(p => p.People)
                .UsingEntity<ClassList>();

            modelBuilder.Entity<Class>()
                .HasMany(p => p.People)
                .WithMany(p => p.Classes)
                .UsingEntity<ClassList>();

            // Seed data
            modelBuilder.Entity<Person>()
                .HasData(Seed.Person());

            modelBuilder.Entity<Class>()
                .HasData(Seed.Class());

            modelBuilder.Entity<ClassList>()
                .HasData(Seed.ClassList());
        }
    }
}
