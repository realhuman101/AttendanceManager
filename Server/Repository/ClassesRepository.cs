using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Repository
{
    public class ClassesRepository : IRepository<Class>
    {
        public List<Class> allObjs { get; set; }

        public ClassesRepository(DataContext context)
        {
            allObjs = context.Classes.ToList();
        }

        public List<Class> Get()
        {
            return allObjs;
        }

        public Class GetByID(int id)
        {
            return allObjs.FirstOrDefault(c => c.ID == id);
        }

        public bool Save()
        {
            return true;
        }
    }
}
