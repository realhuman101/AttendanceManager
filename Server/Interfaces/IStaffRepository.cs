using Server.Models;

namespace Server.Interfaces
{
    public interface IStaffRepository
    {
        public List<Staff> Get();

        public Staff GetByID(int id);

        public string SignIn(string email, string attemptedPassword);

        public Staff GetStaffSession(string sessionVal);

        public bool Save();
    }
}
