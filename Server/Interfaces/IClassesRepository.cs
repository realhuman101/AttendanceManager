using Server.Models;

namespace Server.Interfaces
{
    public interface IClassesRepository
    {
        public List<Class> Get();

        public Class GetByName(string name);

        public List<Person> GetPeople(string name);

        public bool Save();
    }
}