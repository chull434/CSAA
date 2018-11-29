using CSAA.ServiceModels;
using System.Collections.Generic;
using CSAA.Enums;

namespace Server.Services
{
    public interface IProjectTeamMemberService
    {
        List<ProjectTeamMember> GetAllProjectTeamMembers();
        List<User> SearchProjectTeamMembers(string projectId, User user);
        List<User> SearchProjectTeamMembersSprint(string projectId, string sprintId, User user);
        ProjectTeamMember GetProjectTeamMember(string projectTeamMemberId);
        void AddProjectTeamMember(string userId, string projectId, Role role);
        void UpdateProjectTeamMember(string projectTeamMemberId, ProjectTeamMember projectTeamMember);
        void DeleteProjectTeamMember(string projectTeamMemberId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}
