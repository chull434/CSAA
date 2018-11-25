using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IProjectTeamMemberRequest
    {
        List<ProjectTeamMember> GetProjectTeamMembers();
        ProjectTeamMember GetProjectTeamMember(string projectTeamMemberId);
        bool AddProjectTeamMember(string email, string projectId);
        bool UpdateProjectTeamMember(string projectTeamMemberId, ProjectTeamMember projectTeamMember);
        bool DeleteProjectTeamMember(string projectTeamMemberId);
    }
}