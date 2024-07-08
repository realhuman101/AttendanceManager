using Server.Models;

namespace Server.Interfaces
{
    public interface IClassesRepository
    {
        public List<Class> Get();

        public Class GetByID(int id);

        public List<Person> GetByPerson(int id);

        public bool Save();
    }
}