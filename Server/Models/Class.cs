namespace Server.Models
{
    public class Class
    {
        public DateTime StartTime { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int NoPeople { get; set; } // Number of people in the class

        public ICollection<ClassList> ClassLists { get; set; }
    }
}
