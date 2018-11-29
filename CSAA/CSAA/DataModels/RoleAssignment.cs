using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CSAA.Enums;

namespace CSAA.DataModels
{
    public class RoleAssignment
    {
        public Guid Id { get; set; }

        [ForeignKey("ProjectTeamMember")]
        public Guid ProjectTeamMemberId { get; set; }

        public virtual ProjectTeamMember ProjectTeamMember { get; set; }

        public Role Role { get; set; }

        public RoleAssignment()
        {
            Id = Guid.NewGuid();
            Role = Role.TeamMember;
        }

        public RoleAssignment(Role Role, ProjectTeamMember ProjectTeamMember)
        {
            Id = Guid.NewGuid();
            this.Role = Role;
            this.ProjectTeamMember = ProjectTeamMember;
        }
    }
}
