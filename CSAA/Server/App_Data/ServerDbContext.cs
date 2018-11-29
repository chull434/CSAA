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
        public virtual DbSet<UserStory> UserStories { get; set; }
        public virtual DbSet<AcceptanceTest> AcceptanceTests { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}