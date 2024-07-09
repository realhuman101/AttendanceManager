using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;

namespace Server.Models
{
    public class Staff : Person
    {
        private string Password;

        [InverseProperty("Staffs")]
        public virtual List<Class> Classes { get; set; } = null!;
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
    }
}
