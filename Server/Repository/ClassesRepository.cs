using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Repository
{
    public class ClassesRepository : IRepository<Class>
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

        public Class GetByID(int id)
        {
            return dataContext.Classes.FirstOrDefault(c => c.ID == id);
        }

        public bool Save()
        {
            return dataContext.SaveChanges() >= 0; // Returns true if changes were saved
        }
    }
}
