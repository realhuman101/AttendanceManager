using Microsoft.EntityFrameworkCore;

using Server.Models;
using Server.Models.JoinTables;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<ClassList> ClassList => Set<ClassList>();

        public DbSet<Staff> Staffs => Set<Staff>();
        public DbSet<StaffClass> StaffClass => Set<StaffClass>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Person-Class many-to-many relationship
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

            // Configure the Staff-Class many-to-many relationship
            modelBuilder.Entity<StaffClass>()
                .HasKey(cl => new { cl.StaffID, cl.ClassID });

            modelBuilder.Entity<Staff>()
                .HasMany(s => s.Classes)
                .WithMany(c => c.Staffs)
                .UsingEntity<StaffClass>();

            modelBuilder.Entity<Class>()
                .HasMany(s => s.Staffs)
                .WithMany(c => c.Classes)
                .UsingEntity<StaffClass>();

            // Configure the Staff-Session one-to-many relationship
            modelBuilder.Entity<Staff>()
                .HasMany(s => s.Sessions)
                .WithOne(s => s.staff)
                .HasForeignKey(s => s.staffID)
                .IsRequired();

            // Seed data
            modelBuilder.Entity<Person>()
                .HasData(Seed.Person());

            modelBuilder.Entity<Class>()
                .HasData(Seed.Class());

            modelBuilder.Entity<ClassList>()
                .HasData(Seed.ClassList());

            modelBuilder.Entity<Staff>()
                .HasData(Seed.Staff());

            modelBuilder.Entity<StaffClass>()
                .HasData(Seed.StaffClass());
        }
    }
}
