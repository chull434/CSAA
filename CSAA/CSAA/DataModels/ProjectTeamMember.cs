using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CSAA.Enums;

namespace CSAA.DataModels
{
    public class ProjectTeamMember
    {
        public Guid Id { get; set; }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [Key, Column(Order = 1),ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public Role Role { get; set; }

        public ProjectTeamMember()
        {
            Id = Guid.NewGuid();
        }

        public ProjectTeamMember(string UserId, Project Project, Role Role)
        {
            Id = Guid.NewGuid();
            this.UserId = UserId;
            this.Project = Project;
            this.Role = Role;
        }

        public ServiceModels.ProjectTeamMember Map()
        {
            return new ServiceModels.ProjectTeamMember
            {
                Id = Id.ToString(),
                UserId = UserId,
                ProjectId = ProjectId.ToString(),
                Role = Role,
                ProjectTitle = Project.Title,
            };
        }
    }
}
