using System.Web.Helpers;

namespace Server.Models
{
    public class Staff : Person
    {
        private string Password;

        public List<Session> Sessions { get; set; }

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
