using Server.Models;

namespace Server.Interfaces
{
    public interface IPeopleRepository
    {
        public List<Person> people { get; set; }

        public List<Person> GetPeople();
    }
}
