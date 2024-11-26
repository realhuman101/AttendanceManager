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

        public Class GetByID(string id)
        {
            return dataContext.Classes.FirstOrDefault(c => c.ID == id);
        }

        public List<Person> GetPeople(string id)
        {
            List<Person> people = dataContext.ClassList
                                                   .Where(cl => cl.ClassID == id)
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
