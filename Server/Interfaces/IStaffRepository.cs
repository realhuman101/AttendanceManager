using Server.Models;

namespace Server.Interfaces
{
    public interface IStaffRepository
    {
        public List<Staff> Get();

        public Staff GetByID(int id);

        //public List<Class> GetClasses(int id);

        public string SignIn(string email, string attemptedPassword);

        public bool Save();
    }
}
