using Server.Models;

namespace Server.Interfaces
{
    public interface IPeopleRepository
    {
        public List<Person> Get();

        public Person GetByID(int id);

        public List<Class> GetByClasses(int id);

        public bool Save();
    }
}
