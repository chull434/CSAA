using System.Collections.Generic;
using CSAA.Enums;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface ISprintTeamMemberRequest
    {
        List<SprintTeamMember> GetSprintTeamMembers();
        SprintTeamMember GetSprintTeamMember(string sprintTeamMemberId);
        bool AddSprintTeamMember(SprintTeamMember sprintTeamMember);
        bool UpdateSprintTeamMember(string sprintTeamMemberId, SprintTeamMember sprintTeamMember);
        bool DeleteSprintTeamMember(string sprintTeamMemberId);
    }
}
