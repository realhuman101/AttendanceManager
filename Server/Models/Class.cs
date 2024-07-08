using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Class
    {
        public int ID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int NoPeople { get; set; } // Number of people in the class

        public virtual List<Person> People { get; set; }
    }
}
