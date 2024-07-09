using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.JoinTables
{
    public class ClassList // Join table of Classes and People
    {
        public Person Person { get; set; } = null!;
        public Class Class { get; set; } = null!;

        [ForeignKey("Person")]
        public int PersonID { get; set; }
        [ForeignKey("Class")]
        public int ClassID { get; set; }
    }
}
