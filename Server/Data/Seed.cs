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

                dataContext.People.AddRange(people);

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

                dataContext.Classes.AddRange(classes);

                // Class List
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

                dataContext.ClassLists.AddRange(classList);

                // Save seeded data
                dataContext.SaveChanges();
            }
        }
    }
}
