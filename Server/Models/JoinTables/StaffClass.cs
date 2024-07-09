namespace Server.Models.JoinTables
{
    public class StaffClass
    {
        public Staff Staff { get; set; } = null!;
        public Class Class { get; set; } = null!;

        public int StaffID { get; set; }
        public int ClassID { get; set; }
    }
}
