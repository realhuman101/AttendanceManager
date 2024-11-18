using Server.Models;

namespace Server.Interfaces
{
    public interface IClassesRepository
    {
        public List<Class> Get();

        public Class GetByID(string id);

        public List<Person> GetPeople(string id);

        public bool Save();
    }
}