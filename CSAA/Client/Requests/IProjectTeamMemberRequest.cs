namespace Client.Requests
{
    public interface IProjectTeamMemberRequest
    {
        bool AddTeamMember(string email, string projectId);
    }
}