namespace Server.Models
{
    public class Session
    {
        public int ID { get; set; }
        public string Value { get; set; } = null!;

        public int staffID { get; set; }
        public Staff staff { get; set; } = null!;
    }
}
