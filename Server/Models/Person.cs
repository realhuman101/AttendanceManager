namespace Server.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Present { get; set; }
        public string Email { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
