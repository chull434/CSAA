using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSAA.Models
{
    public class ProjectTeamMember
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Project Project { get; set; }

        public Role Role { get; set; }

        public ProjectTeamMember(string UserId, Project Project, Role Role)
        {
            this.UserId = UserId;
            this.Project = Project;
            this.Role = Role;
        }
    }
}
