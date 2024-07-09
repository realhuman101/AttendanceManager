using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;

using Server.Interfaces;

namespace Server.Models
{
    public class Staff : Person, IBaseObject
    {
        [Key]
        public int ID { get; set; }

        private string Password;

        [InverseProperty("Staffs")]
        public virtual List<Class> Classes { get; set; } = null!;
        [InverseProperty("staff")]
        public virtual List<Session> Sessions { get; set; }

        public bool checkPassword(string attempt)
        {
            string hashed = Crypto.HashPassword(attempt);

            return Crypto.VerifyHashedPassword(hashed, Password);
        }

        public void setPassword(string newPassword)
        {
            Password = Crypto.HashPassword(newPassword);
        }

        public string generateSessionID()
        {
            return Crypto.HashPassword(Password + DateTime.Now.ToString());
        }
    }
}
