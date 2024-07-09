using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

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

            if (staff.checkPassword(attemptedPassword))
            {
                string sessIDVal = Crypto.HashPassword(email + DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                Session session = new Session();
                session.Value = staff.generateSessionID();
                session.staff = staff;
                session.staffID = staff.ID;
                session.Created = DateTime.Now;

                dataContext.Staffs.FirstOrDefault(p => p.Email == email).Sessions.Add(session);
                Save();
                return session.Value;
            }

            return null;
        }

        public Staff GetStaffSession(string sessionVal)
        {            
            foreach (Staff staff in dataContext.Staffs)
            {
                foreach (Session _session in staff.Sessions)
                {
                    if (_session.Value == sessionVal)
                    {
                        return staff;
                    }
                }
            }

            return null;
        }

        public bool Save()
        {
            return dataContext.SaveChanges() >= 0; // Returns true if changes were saved
        }
    }
}
