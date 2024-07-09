using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.JoinTables
{
    public class StaffClass
    {
        public Staff Staff { get; set; } = null!;
        public Class Class { get; set; } = null!;

        [ForeignKey("Staff")]
        public int StaffID { get; set; }
        [ForeignKey("Class")]
        public int ClassID { get; set; }
    }
}
