
namespace CSAA.ServiceModels
{
    public class SprintTeamMember
    {
        public string SprintId { get; set; }
        public string ProjectTeamMemberId { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }

        public SprintTeamMember()
        {

        }

        public SprintTeamMember(string SprintId, string ProjectTeamMemberId)
        {
            this.SprintId = SprintId;
            this.ProjectTeamMemberId = ProjectTeamMemberId;
        }
    }
}
