using System.ComponentModel.DataAnnotations;

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
        public Staff staff { get; set; } = null!;
    }
}
