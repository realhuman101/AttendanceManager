using Server.Models;

namespace Server.Interfaces
{
    public interface IPeopleRepository
    {
        public List<Person> Get();

        public Person GetByID(string id);

        public List<Class> GetClasses(string id);

        public List<Person> GetByName(string name);

        public bool Save();
    }
}
