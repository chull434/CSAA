using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface ITaskRequest
    {
        List<Task> GetTasks();
        Task GetTaskById(string taskId);
        string CreateTask(Task task);
        bool UpdateTask(string taskId, Task task);
        bool DeleteTask(string taskId);
    }
}
