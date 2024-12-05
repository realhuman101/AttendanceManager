using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Server.Models;
using Server.Models.JoinTables;

namespace Server.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<ClassList> ClassList => Set<ClassList>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Class primary key as Name
            modelBuilder.Entity<Class>()
                .HasKey(c => c.Name); // ClassName is now the primary key

            // Configure the Person-Class many-to-many relationship
            modelBuilder.Entity<ClassList>()
                .HasKey(cl => new { cl.PersonID, cl.ClassName }); // Composite key

            modelBuilder.Entity<ClassList>()
                .HasOne(cl => cl.Class)
                .WithMany(c => c.ClassList)
                .HasForeignKey(cl => cl.ClassName)
                .HasPrincipalKey(c => c.Name); // Foreign key links to ClassName

            modelBuilder.Entity<ClassList>()
                .HasOne(cl => cl.Person)
                .WithMany(p => p.ClassList)
                .HasForeignKey(cl => cl.PersonID);

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
