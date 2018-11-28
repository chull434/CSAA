using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CSAA.Enums;

namespace CSAA.DataModels
{
    public class ProjectTeamMember
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual List<RoleAssignment> RoleAssignments { get; set; }

        public ProjectTeamMember()
        {
            Id = Guid.NewGuid();
            RoleAssignments = new List<RoleAssignment>();
        }

        public ProjectTeamMember(string UserId, Project Project, Role Role)
        {
            Id = Guid.NewGuid();
            RoleAssignments = new List<RoleAssignment>();
            this.UserId = UserId;
            this.Project = Project;
            AddRole(Role);
        }

        public ServiceModels.ProjectTeamMember Map()
        {
            var projectTeamMember = new ServiceModels.ProjectTeamMember
            {
                Id = Id.ToString(),
                UserId = UserId,
                ProjectId = ProjectId.ToString(),
                ProjectTitle = Project.Title,
            };
            foreach (var roleAssignment in RoleAssignments.OrderBy(r => r.Role))
            {
                projectTeamMember.Roles += roleAssignment.Role + ", ";
            }
            return projectTeamMember;
        }

        public void AddRole(Role role)
        {
            if(HasRole(role)) return;
            RoleAssignments.Add(new RoleAssignment(role, this));
        }

        public bool HasRole(Role role)
        {
            return RoleAssignments.Any(r => r.Role == role);
        }
    }
}
