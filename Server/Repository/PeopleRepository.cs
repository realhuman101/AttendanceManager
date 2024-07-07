using Server.Data;
using Server.Models;
using Server.Interfaces;

namespace Server.Repository
{
    public class PeopleRepository : IRepository<Person>
    {
        private readonly DataContext dataContext;

        public PeopleRepository(DataContext context)
        {
            dataContext = context;
        }

        public List<Person> Get()
        {
            return dataContext.People.OrderBy(p => p.ID).ToList();
        }

        public Person GetByID(int id)
        {
            return dataContext.People.FirstOrDefault(p => p.ID == id);
        }

        public bool Save()
        {
            return dataContext.SaveChanges() >= 0; // Returns true if changes were saved
        }
    }
}
