using CSAA.Enums;

namespace CSAA.ServiceModels
{
    public class ProjectTeamMember
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectId { get; set; }
        public Role Role { get; set; }
    }
}