using Server.Data;
using Server.Models;
using Server.Interfaces;

namespace Server.Repository
{
    public class People : IPeopleRepository
    {
        private readonly DataContext dataContext;
        public List<Person> people { get; set; }

        public People(DataContext context)
        {
            this.dataContext = context;
        }

        public List<Person> GetPeople()
        {
            return dataContext.People.OrderBy(p => p.ID).ToList();
        }

        public Person GetPerson(int id)
        {
            return dataContext.People.FirstOrDefault(p => p.ID == id);
        }
    }
}
