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
                List<ClassList> list = new List<ClassList>()
                {
                    new ClassList {
                        PersonID = 0,
                        ClassID = 0,
                        Person = new Person { ID = 0, Name = "John Doe", Present = true, Email = "john@doe.com"},
                        Class = new Class { ID = 0, Name = "Math", StartTime = new DateTime(2021, 1, 1, 8, 0, 0), EndTime = new DateTime(2021, 1, 1, 9, 0, 0) }
                    },
                    new ClassList {
                        PersonID = 1,
                        ClassID = 1,
                        Person = new Person { ID = 1, Name = "Emma Brown", Present = false, Email = "emma@brown.com"},
                        Class = new Class { ID = 1, Name = "English", StartTime = new DateTime(2021, 1, 1, 9, 0, 0), EndTime = new DateTime(2021, 1, 1, 10, 0, 0) }
                    },
                    new ClassList {
                        PersonID = 1,
                        ClassID = 2,
                        Person = new Person { ID = 1, Name = "Emma Brown", Present = true, Email = "emma@brown.com"},
                        Class = new Class { ID = 2, Name = "Biology", StartTime = new DateTime(2021, 1, 1, 10, 0, 0), EndTime = new DateTime(2021, 1, 1, 11, 0, 0) }
                    },
                    new ClassList {
                        PersonID = 2,
                        ClassID = 3,
                        Person = new Person { ID = 2, Name = "Robert Fox", Present = true, Email = "robert@fox.com"},
                        Class = new Class { ID = 3, Name = "Chemistry", StartTime = new DateTime(2021, 1, 1, 11, 0, 0), EndTime = new DateTime(2021, 1, 1, 12, 0, 0) }
                    },
                    new ClassList {
                        PersonID = 3,
                        ClassID = 0,
                        Person = new Person { ID = 3, Name = "Clara White", Present = true, Email = "clara@white.com"},
                        Class = new Class { ID = 0, Name = "Math", StartTime = new DateTime(2021, 1, 1, 8, 0, 0), EndTime = new DateTime(2021, 1, 1, 9, 0, 0) }
                    },
                    new ClassList {
                        PersonID = 4,
                        ClassID = 4,
                        Person = new Person { ID = 4, Name = "Samantha Reed", Present = true, Email = "sam@reed.com"},
                        Class = new Class { ID = 4, Name = "Physics", StartTime = new DateTime(2021, 1, 1, 13, 0, 0), EndTime = new DateTime(2021, 1, 1, 14, 0, 0) }
                    },
                    new ClassList {
                        PersonID = 5,
                        ClassID = 5,
                        Person = new Person { ID = 5, Name = "Luke Morris", Present = false, Email = "luke@morris.com"},
                        Class = new Class { ID = 5, Name = "Art History", StartTime = new DateTime(2021, 1, 1, 14, 30, 0), EndTime = new DateTime(2021, 1, 1, 15, 30, 0) }
                    },
                    new ClassList {
                        PersonID = 6,
                        ClassID = 1,
                        Person = new Person { ID = 6, Name = "Michael Chen", Present = true, Email = "michael@chen.com"},
                        Class = new Class { ID = 1, Name = "English", StartTime = new DateTime(2021, 1, 1, 9, 0, 0), EndTime = new DateTime(2021, 1, 1, 10, 0, 0) }
                    }
                };

                dataContext.ClassLists.AddRange(list);
                dataContext.SaveChanges();
            }
        }
    }
}
