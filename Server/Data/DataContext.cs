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
            // Configure the join table
            modelBuilder.Entity<ClassList>()
                .HasKey(cl => new { cl.PersonID, cl.ClassID });
            
            modelBuilder.Entity<ClassList>()
                .HasOne(cl => cl.Person)
                .WithMany(p => p.ClassLists)
                .HasForeignKey(cl => cl.PersonID);

            modelBuilder.Entity<ClassList>()
                .HasOne(cl => cl.Class)
                .WithMany(c => c.ClassLists)
                .HasForeignKey(cl => cl.ClassID);

            // Seed data

            // People
            List<Person> people = new List<Person>()
            {
                new Person { Name = "John Doe", Email = "john.doe@example.com", Present = true },
                new Person { Name = "Jane Smith", Email = "jane.smith@example.com", Present = false },
                new Person { Name = "Alice Johnson", Email = "alice.johnson@example.com", Present = true },
                new Person { Name = "Mark Brown", Email = "mark.brown@example.com", Present = true },
                new Person { Name = "Lucy Green", Email = "lucy.green@example.com", Present = true },
                new Person { Name = "Emma White", Email = "emma.white@example.com", Present = false },
                new Person { Name = "Noah Wilson", Email = "noah.wilson@example.com", Present = true },
                new Person { Name = "Liam Murphy", Email = "liam.murphy@example.com", Present = true },
                new Person { Name = "Sophia Davis", Email = "sophia.davis@example.com", Present = true },
                new Person { Name = "Ethan Miller", Email = "ethan.miller@example.com", Present = false }
            };

            // Classes
            List<Class> classes = new List<Class>()
            {
                new Class { Name = "Math 101", Room = "Room 101", StartTime = new DateTime(2021, 9, 1, 9, 0, 0), EndTime = new DateTime(2021, 9, 1, 10, 30, 0), NoPeople = 30 },
                new Class { Name = "History 101", Room = "Room 102", StartTime = new DateTime(2021, 9, 1, 11, 0, 0), EndTime = new DateTime(2021, 9, 1, 12, 30, 0), NoPeople = 25 },
                new Class { Name = "Science 101", Room = "Room 103", StartTime = new DateTime(2021, 9, 1, 13, 0, 0), EndTime = new DateTime(2021, 9, 1, 14, 30, 0), NoPeople = 20 },
                new Class { Name = "English Literature", Room = "Room 104", StartTime = new DateTime(2021, 9, 1, 15, 0, 0), EndTime = new DateTime(2021, 9, 1, 16, 30, 0), NoPeople = 22 },
                new Class { Name = "Computer Science", Room = "Room 105", StartTime = new DateTime(2021, 9, 2, 9, 0, 0), EndTime = new DateTime(2021, 9, 2, 10, 30, 0), NoPeople = 18 },
                new Class { Name = "Philosophy", Room = "Room 106", StartTime = new DateTime(2021, 9, 2, 11, 0, 0), EndTime = new DateTime(2021, 9, 2, 12, 30, 0), NoPeople = 15 }
            };

            // Class list
            List<ClassList> classList = new List<ClassList>
            {
                new ClassList { Person = people[0], Class = classes[0] },
                new ClassList { Person = people[0], Class = classes[1] },
                new ClassList { Person = people[1], Class = classes[1] },
                new ClassList { Person = people[2], Class = classes[2] },
                new ClassList { Person = people[3], Class = classes[0] },
                new ClassList { Person = people[4], Class = classes[3] },
                new ClassList { Person = people[4], Class = classes[4] },
                new ClassList { Person = people[5], Class = classes[4] },
                new ClassList { Person = people[6], Class = classes[5] },
                new ClassList { Person = people[7], Class = classes[5] },
                new ClassList { Person = people[8], Class = classes[3] },
                new ClassList { Person = people[9], Class = classes[2] },
                new ClassList { Person = people[9], Class = classes[5] }
            };

            // Generating IDs
            modelBuilder.Entity<Person>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Class>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd();

            // Adding to modelBuilder
            modelBuilder.Entity<Person>()
                .HasData(people.ToArray());

            modelBuilder.Entity<Class>()
                .HasData(classes.ToArray());

            modelBuilder.Entity<ClassList>()
                .HasData(classList.ToArray());
        }
    }
}
