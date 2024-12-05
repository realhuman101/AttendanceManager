using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Repository
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly DataContext dataContext;

        public ClassesRepository(DataContext context)
        {
            dataContext = context;
        }

        public List<Class> Get()
        {
            return dataContext.Classes.ToList();
        }

        public Class GetByName(string name)
        {
            return dataContext.Classes.FirstOrDefault(c => c.Name == name);
        }

        public List<Person> GetPeople(string name)
        {
            List<Person> people = dataContext.ClassList
                                                   .Where(cl => cl.ClassID == name)
                                                   .Include(cl => cl.Person)
                                                   .Select(cl => cl.Person)
                                                   .ToList();

            return people;
        }

        public bool Save()
        {
            return dataContext.SaveChanges() >= 0; // Returns true if changes were saved
        }
    }
}
