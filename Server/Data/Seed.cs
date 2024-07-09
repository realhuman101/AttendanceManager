using Server.Models;
using System.Runtime.CompilerServices;

namespace Server.Data
{
    public static class Seed
    {
        public static List<Class> Class()
        {
            List<Class> classes = new List<Class>() 
            {
                new Class { ID = 1, Name = "Math 101", Room = "Room 101", StartTime = DateTime.Parse("2021-09-01 09:00"), EndTime = DateTime.Parse("2021-09-01 10:30"), NoPeople = 30 },
                new Class { ID = 2, Name = "History 101", Room = "Room 102", StartTime = DateTime.Parse("2021-09-01 11:00"), EndTime = DateTime.Parse("2021-09-01 12:30"), NoPeople = 25 },
                new Class { ID = 3, Name = "Science 101", Room = "Room 103", StartTime = DateTime.Parse("2021-09-01 13:00"), EndTime = DateTime.Parse("2021-09-01 14:30"), NoPeople = 20 }
            };

            return classes;
        }

        public static List<Person> Person()
        {
            List<Person> people = new List<Person>()
            {
                new Person { ID = 1, Name = "John Doe", Email = "john.doe@example.com", Present = true },
                new Person { ID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Present = false },
                new Person { ID = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Present = true }
            };

            return people;
        }

        public static List<ClassList> ClassList()
        {
            List<Class> _class = Class();
            List<Person> person = Person();

            List<ClassList> list = new List<ClassList>() { 
                new ClassList() { PersonID = person[1-1].ID, ClassID = _class[1-1].ID },
                new ClassList() { PersonID = person[1-1].ID, ClassID = _class[2-1].ID },
                new ClassList() { PersonID = person[2-1].ID, ClassID = _class[2-1].ID },
                new ClassList() { PersonID = person[3-1].ID, ClassID = _class[1-1].ID },
                new ClassList() { PersonID = person[3-1].ID, ClassID = _class[3-1].ID }
            };

            return list;
        }

        public static List<Staff> Staff()
        {
            List<Staff> staff = new List<Staff>()
            {
                new Staff { ID = 1, Name = "S John Doe", Email = "Sjohn.doe@example.com", Present = false, Password = "test123/" },
                new Staff { ID = 2, Name = "S Jane Smith", Email = "Sjane.smith@example.com", Present = false, Password = "testingThis" },
                new Staff { ID = 3, Name = "S Alice Johnson", Email = "Salice.johnson@example.com", Present = true, Password = "Password" }
            };

            return staff;
        }
    }
}
