using System;

namespace CSAA.Models
{
    public class ProjectTeamMember
    {
        public Guid UserId { get; set; }
        public Project Project { get; set; }
        public Role Role { get; set; }
    }
}
