using System.Security.Cryptography;

namespace Server.Models
{
    public class Staff : Person
    {
        public string Salt { get; set; }
        public string Password { get; set; }

        public Staff() 
        {
            byte[] buffer = new byte[1024];

            RandomNumberGenerator.Create().GetBytes(buffer);
            Salt = BitConverter.ToString(buffer);
        }
    }
}
