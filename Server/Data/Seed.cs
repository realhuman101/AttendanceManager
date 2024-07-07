using Server.Models;

namespace Server.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedData()
        {
            // TODO: Write after get student list
            if (!dataContext.ClassLists.Any())
            {
                // Random people made for testing

                // People
                List<Person> people = new List<Person>()
                {
                    new Person { ID = 1, Name = "John Doe", Email = "john.doe@example.com", Present = true },
                    new Person { ID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Present = false },
                    new Person { ID = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Present = true },
                    new Person { ID = 4, Name = "Mark Brown", Email = "mark.brown@example.com", Present = true },
                    new Person { ID = 5, Name = "Lucy Green", Email = "lucy.green@example.com", Present = true },
                    new Person { ID = 6, Name = "Emma White", Email = "emma.white@example.com", Present = false },
                    new Person { ID = 7, Name = "Noah Wilson", Email = "noah.wilson@example.com", Present = true },
                    new Person { ID = 8, Name = "Liam Murphy", Email = "liam.murphy@example.com", Present = true },
                    new Person { ID = 9, Name = "Sophia Davis", Email = "sophia.davis@example.com", Present = true },
                    new Person { ID = 10, Name = "Ethan Miller", Email = "ethan.miller@example.com", Present = false }
                };

                dataContext.People.AddRange(people);

                // Classes
                List<Class> classes = new List<Class>()
                {
                                new Class { ID = 1, Name = "Math 101", Room = "Room 101", StartTime = new DateTime(2021, 9, 1, 9, 0, 0), EndTime = new DateTime(2021, 9, 1, 10, 30, 0), NoPeople = 30 },
                                new Class { ID = 2, Name = "History 101", Room = "Room 102", StartTime = new DateTime(2021, 9, 1, 11, 0, 0), EndTime = new DateTime(2021, 9, 1, 12, 30, 0), NoPeople = 25 },
                                new Class { ID = 3, Name = "Science 101", Room = "Room 103", StartTime = new DateTime(2021, 9, 1, 13, 0, 0), EndTime = new DateTime(2021, 9, 1, 14, 30, 0), NoPeople = 20 },
                                new Class { ID = 4, Name = "English Literature", Room = "Room 104", StartTime = new DateTime(2021, 9, 1, 15, 0, 0), EndTime = new DateTime(2021, 9, 1, 16, 30, 0), NoPeople = 22 },
                                new Class { ID = 5, Name = "Computer Science", Room = "Room 105", StartTime = new DateTime(2021, 9, 2, 9, 0, 0), EndTime = new DateTime(2021, 9, 2, 10, 30, 0), NoPeople = 18 },
                                new Class { ID = 6, Name = "Philosophy", Room = "Room 106", StartTime = new DateTime(2021, 9, 2, 11, 0, 0), EndTime = new DateTime(2021, 9, 2, 12, 30, 0), NoPeople = 15 }
                };

                dataContext.Classes.AddRange(classes);

                // Class List
                List<ClassList> classList = new List<ClassList>()
                {
                    new ClassList { PersonID = 1, ClassID = 1 },
                    new ClassList { PersonID = 1, ClassID = 2 },
                    new ClassList { PersonID = 2, ClassID = 2 },
                    new ClassList { PersonID = 3, ClassID = 3 },
                    new ClassList { PersonID = 4, ClassID = 1 },
                    new ClassList { PersonID = 5, ClassID = 4 },
                    new ClassList { PersonID = 5, ClassID = 5 },
                    new ClassList { PersonID = 6, ClassID = 5 },
                    new ClassList { PersonID = 7, ClassID = 6 },
                    new ClassList { PersonID = 8, ClassID = 6 },
                    new ClassList { PersonID = 9, ClassID = 4 },
                    new ClassList { PersonID = 10, ClassID = 3 },
                    new ClassList { PersonID = 10, ClassID = 6 }
                };

                dataContext.ClassLists.AddRange(classList);

                // Save seeded data
                dataContext.SaveChanges();
            }
        }
    }
}
