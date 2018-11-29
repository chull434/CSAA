using CSAA.ServiceModels;
using System.Collections.Generic;
using CSAA.Enums;

namespace Server.Services
{
    public interface ISprintTeamMemberService
    {
        List<SprintTeamMember> GetAllSprintTeamMembers();
        SprintTeamMember GetSprintTeamMember(string sprintTeamMemberId);
        void AddSprintTeamMember(string sprintId, string projectTeamMemberId);
        void UpdateSprintTeamMember(string sprintTeamMemberId, SprintTeamMember sprintTeamMember);
        void DeleteSprintTeamMember(string sprintTeamMemberId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}
