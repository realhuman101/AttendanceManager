namespace Server.Models
{
    public class Staff : Person
    {
        public string Password { get; set; } = null!;

        public List<Session> Sessions { get; set; }
    }
}
