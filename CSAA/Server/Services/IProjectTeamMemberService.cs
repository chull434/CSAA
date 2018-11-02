using CSAA.ServiceModels;
using System.Collections.Generic;

namespace Server.Services
{
    public interface IProjectTeamMemberService
    {
        List<ProjectTeamMember> GetAllProjectTeamMembers();
        ProjectTeamMember GetProjectTeamMember(string projectTeamMemberId);
        void AddProjectTeamMember(string userId, string projectId);
        void UpdateProjectTeamMember(string projectTeamMemberId, ProjectTeamMember projectTeamMember);
        void DeleteProjectTeamMember(string projectTeamMemberId);
    }
}
