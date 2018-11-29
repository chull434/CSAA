using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSAA.DataModels
{
    public class SprintTeamMember
    {
        [ForeignKey("Sprint")]
        public Guid SprintId { get; set; }

        public virtual Sprint Sprint { get; set; }

        [ForeignKey("ProjectTeamMember")]
        public Guid ProjectTeamMemberId { get; set; }

        public virtual ProjectTeamMember ProjectTeamMember { get; set; }
    }
}
