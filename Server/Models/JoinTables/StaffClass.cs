using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.JoinTables
{
    public class StaffClass
    {
        [ForeignKey("StaffID")]
        public Staff Staff { get; set; } = null!;
        [ForeignKey("ClassID")]
        public Class Class { get; set; } = null!;

        public int StaffID { get; set; }
        public int ClassID { get; set; }
    }
}
