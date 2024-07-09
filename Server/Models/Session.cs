using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Interfaces;

namespace Server.Models
{
    public class Session : IBaseObject
    {
        [Key]
        public int ID { get; set; }
        public string Value { get; set; } = null!;
        public DateTime Created { get; set; }

        public int staffID { get; set; }
        [ForeignKey("staffID")]
        public Staff staff { get; set; } = null!;
    }
}
