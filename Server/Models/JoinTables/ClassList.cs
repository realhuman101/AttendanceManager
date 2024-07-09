using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.JoinTables
{
    public class ClassList // Join table of Classes and People
    {
        [ForeignKey("PersonID")]
        public Person Person { get; set; } = null!;
        [ForeignKey("ClassID")]
        public Class Class { get; set; } = null!;

        public int PersonID { get; set; }
        public int ClassID { get; set; }
    }
}
