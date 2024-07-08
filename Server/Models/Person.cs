using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;
        public bool Present { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<Class> Classes { get; set; } = null!;
    }
}
