using System.Collections.Generic;
using CSAA.Enums;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IProjectTeamMemberRequest
    {
        List<ProjectTeamMember> GetProjectTeamMembers();
        List<User> SearchProjectTeamMembers(string projectId, User user);
        List<User> SearchProjectTeamMembersSprint(string projectId, string sprintId, User user);
        ProjectTeamMember GetProjectTeamMember(string projectTeamMemberId);
        bool AddProjectTeamMember(string email, string projectId, Role role);
        bool UpdateProjectTeamMember(string projectTeamMemberId, ProjectTeamMember projectTeamMember);
        bool DeleteProjectTeamMember(string projectTeamMemberId);
    }
}