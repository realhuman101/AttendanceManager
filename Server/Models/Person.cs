using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Server.Interfaces;

namespace Server.Models
{
    public class Person : IBaseObject
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; } = null!;
        public bool Present { get; set; }
        public string Email { get; set; } = null!;

        [InverseProperty("People")]
        public virtual List<Class> Classes { get; set; } = null!;
    }
}
