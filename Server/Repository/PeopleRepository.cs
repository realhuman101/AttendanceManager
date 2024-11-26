using Server.Data;
using Server.Models;
using Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly DataContext dataContext;

        public PeopleRepository(DataContext context)
        {
            dataContext = context;
        }

        public List<Person> Get()
        {
            return dataContext.People.ToList();
        }

        public Person GetByID(string id)
        {
            return dataContext.People.FirstOrDefault(p => p.ID == id);
        }

        public List<Class> GetClasses(string id)
        {
            List<Class> classes = dataContext.ClassList
                                            .Where(cl => cl.PersonID == id)
                                            .Include(cl => cl.Class)
                                            .Select(cl => cl.Class)
                                            .ToList();

            return classes;
        }

        public List<Person> GetByName(string name)
        {
            return dataContext.People.Where(p => p.Name == name).ToList();
        }

        public bool Save()
        {
            return dataContext.SaveChanges() >= 0; // Returns true if changes were saved
        }
    }
}
