using System.Data.Entity;
using CSAA.Models;
using Server.Models;

namespace Server.App_Data
{
    public class ServerDbContext : ApplicationDbContext
    {
        public ServerDbContext() : base()
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
    }
}