using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface ISprintRequest
    {
        List<Sprint> GetSprints();
        Sprint GetSprint(string sprintId);
        string CreateSprint(Sprint sprint);
        bool UpdateSprint(string sprintId, Sprint sprint);
        bool DeleteSprint(string sprintId);
    }
}
