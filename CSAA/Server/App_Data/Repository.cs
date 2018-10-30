namespace Server.App_Data
{
    public class Repository
    {
        protected ServerDbContext context;

        public void Save()
        {
            context.SaveChanges();
        }
    }
}