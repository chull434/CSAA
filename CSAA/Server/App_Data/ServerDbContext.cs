using System.Data.Entity;
using CSAA.DataModels;

namespace Server.App_Data
{
    public class ServerDbContext : ApplicationDbContext
    {
        public ServerDbContext() : base()
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTeamMember> ProjectTeamMembers { get; set; }
    }
}