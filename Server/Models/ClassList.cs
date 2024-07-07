namespace Server.Models
{
    public class ClassList // Join table of Classes and People
    {
        public int PersonID { get; set; }
        public int ClassID { get; set; }

        public Person Person { get; set; }
        public Class Class { get; set; }
    }
}
