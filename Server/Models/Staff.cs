using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Web.Helpers;

using Server.Interfaces;

namespace Server.Models
{
    public class Staff : IBaseObject
    {
        [Key]
        public int ID { get; set; }

        public string Password { get; private set; }
        public string Name { get; set; } = null!;
        public bool Present { get; set; }
        public string Email { get; set; } = null!;

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
            return Crypto.HashPassword(Password + DateTime.Now.ToString() + RandomNumberGenerator.GetInt32(100).ToString());
        }
    }
}
