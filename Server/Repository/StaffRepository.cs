using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext dataContext;

        public StaffRepository(DataContext context)
        {
            dataContext = context;
        }

        public List<Staff> Get()
        {
            return dataContext.Staffs.ToList();
        }

        public Staff GetByID(int id)
        {
            return dataContext.Staffs.FirstOrDefault(p => p.ID == id);
        }

        public string SignIn(string email, string attemptedPassword)
        {
            Staff? staff = dataContext.Staffs.FirstOrDefault(p => p.Email == email);

            if (staff == null)
                return null;


        }

        public bool Save()
        {
            return dataContext.SaveChanges() >= 0; // Returns true if changes were saved
        }
    }
}
