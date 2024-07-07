using Server.Models;

namespace Server.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedData()
        {
            if (!dataContext.ClassLists.Any())
            {
                // TODO: Write after get student list

                //dataContext.ClassLists.AddRange();
                dataContext.SaveChanges();
            }
        }
    }
}
