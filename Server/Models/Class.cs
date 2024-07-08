using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Class
    {
        [Key]
        public int ID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; } = null!;
        public string Room { get; set; } = null!;
        public int NoPeople { get; set; } // Number of people in the class

        public virtual ICollection<Person> People { get; set; } = null!;
    }
}
