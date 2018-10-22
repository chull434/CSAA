using System.Data.Entity;
using Server.Models;

namespace Server.App_Data
{
    public class ServerDbContext : ApplicationDbContext
    {
        public ServerDbContext() : base()
        {

        }
    }
}