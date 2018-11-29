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
        Task GetTask(string TaskID);
        string CreateTask(Task task);
        void UpdateTask(string taskId, Task task);
        void DeleteTask(string taskId);
    }
}
