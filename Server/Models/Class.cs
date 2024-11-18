using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Interfaces;

namespace Server.Models
{
    public class Class : IBaseObject
    {
        [Key]
        public string ID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; } = null!;
        public string Room { get; set; } = null!;
        public int NoPeople { get; set; } // Number of people in the class

        public virtual List<Person> People { get; set; } = null!;
    }
}
