using Server.Models;

namespace Server.Data
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            // Fake Classes
            var class1 = new Class { Name = "Math 101", Room = "Room 101", StartTime = DateTime.Parse("2021-09-01 09:00"), EndTime = DateTime.Parse("2021-09-01 10:30"), NoPeople = 30 };
            var class2 = new Class { Name = "History 101", Room = "Room 102", StartTime = DateTime.Parse("2021-09-01 11:00"), EndTime = DateTime.Parse("2021-09-01 12:30"), NoPeople = 25 };
            var class3 = new Class { Name = "Science 101", Room = "Room 103", StartTime = DateTime.Parse("2021-09-01 13:00"), EndTime = DateTime.Parse("2021-09-01 14:30"), NoPeople = 20 };

            // Fake People
            var person1 = new Person { Name = "John Doe", Email = "john.doe@example.com", Present = true };
            var person2 = new Person { Name = "Jane Smith", Email = "jane.smith@example.com", Present = false };
            var person3 = new Person { Name = "Alice Johnson", Email = "alice.johnson@example.com", Present = true };

            List<ClassList> list = new List<ClassList>() { 
                new ClassList() { Person = person1, Class = class1 },
                new ClassList() { Person = person1, Class = class2 },
                new ClassList() { Person = person2, Class = class2 },
                new ClassList() { Person = person3, Class = class1 },
                new ClassList() { Person = person3, Class = class3 }
            };

            context.ClassList.AddRange(list.ToArray());
            context.SaveChanges();
        }
    }
}
