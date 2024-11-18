using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.JoinTables
{
    public class ClassList // Join table of Classes and People
    {
        public Person Person { get; set; } = null!;
        public Class Class { get; set; } = null!;

        [ForeignKey("Person")]
        public string PersonID { get; set; }
        [ForeignKey("Class")]
        public string ClassID { get; set; }
    }
}
