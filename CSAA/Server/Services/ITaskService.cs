using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSAA.ServiceModels;

namespace Server.Services
{
    public interface ITaskService
    {
        List<Task> GetAllTasks();
        Task GetTask(string TaskId, string userId);
        string CreateTask(Task task);
        void UpdateTask(string taskId, Task task, string userId);
        void DeleteTask(string taskId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}
