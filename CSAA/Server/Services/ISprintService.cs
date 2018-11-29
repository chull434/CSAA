using CSAA.ServiceModels;
using System.Collections.Generic;

namespace Server.Services
{
    public interface ISprintService
    {
        List<Sprint> GetSprints();
        Sprint GetSprint(string sprintId, string userId);
        string CreateSprint(Sprint sprint, string userId);
        void UpdateSprint(string sprintId, Sprint sprint);
        void DeleteSprint(string sprintId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}
