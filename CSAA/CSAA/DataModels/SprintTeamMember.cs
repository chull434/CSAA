using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSAA.DataModels
{
    public class SprintTeamMember
    {
        public Guid Id { get; set; }

        [ForeignKey("Sprint")]
        public Guid SprintId { get; set; }

        public virtual Sprint Sprint { get; set; }

        [ForeignKey("ProjectTeamMember")]
        public Guid ProjectTeamMemberId { get; set; }

        public virtual ProjectTeamMember ProjectTeamMember { get; set; }

        public SprintTeamMember()
        {
            Id = Guid.NewGuid();
        }

        public SprintTeamMember(Sprint sprint, ProjectTeamMember projectTeamMember)
        {
            Id = Guid.NewGuid();
            Sprint = sprint;
            ProjectTeamMember = projectTeamMember;
        }

        public ServiceModels.SprintTeamMember Map()
        {
            return new ServiceModels.SprintTeamMember
            {
                SprintId = SprintId.ToString(),
                ProjectTeamMemberId = ProjectTeamMemberId.ToString(),
                UserId = ProjectTeamMember.UserId
            };

        }
    }
}
