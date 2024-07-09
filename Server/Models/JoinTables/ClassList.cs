namespace Server.Models.JoinTables
{
    public class ClassList // Join table of Classes and People
    {
        public Person Person { get; set; } = null!;
        public Class Class { get; set; } = null!;

        public int PersonID { get; set; }
        public int ClassID { get; set; }
    }
}
