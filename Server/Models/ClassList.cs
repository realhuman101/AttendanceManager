using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class ClassList // Join table of Classes and People
    {
        public int PersonID { get; set; }
        public int ClassID { get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }
        [ForeignKey("ClassID")]
        public Class Class { get; set; }
    }
}
