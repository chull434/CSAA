using System.Data.Entity;
using Server.App_Data;

namespace FunctionalTests.App_Data
{
    public class FunctionalDbContext : ServerDbContext
    {
        public FunctionalDbContext() : base()
        {
            foreach (var user in Users)
            {
                Users.Remove(user);
            }
            SaveChanges();
        }
    }
}
