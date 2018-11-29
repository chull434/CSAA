using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CSAA.ServiceModels;
using Task = CSAA.ServiceModels.Task;

namespace Client.Requests
{
    public class TaskRequest : Request, ITaskRequest
    {
        #region Constructor

        public TaskRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<Task> GetTasks()
        {
            return GetTasksAsync().GetAwaiter().GetResult();
        }

        public Task GetTaskById(string TaskId)
        {
            return GetTaskByIdAsync(TaskId).GetAwaiter().GetResult();
        }

        public string CreateTask(Task task)
        {
            return CreateTaskAsync(task).GetAwaiter().GetResult();
        }

        public bool UpdateTask(string taskId, Task task)
        {
            return UpdateTaskAsync(taskId, task).GetAwaiter().GetResult();
        }

        public bool DeleteTask(string taskId)
        {
            return DeleteTaskAsync(taskId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<Task>> GetTasksAsync()
        {
            var response = await client.GetAsync("api/Task").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<Task>>().ConfigureAwait(false);
        }

        private async Task<Task> GetTaskByIdAsync(string taskId)
        {
            var response = await client.GetAsync("api/Task/" + taskId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<Task>().ConfigureAwait(false);
        }

        private async Task<string> CreateTaskAsync(Task task)
        {
            var response = await client.PostAsJsonAsync("api/Task", task).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var taskId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return taskId.Substring(1, taskId.Length - 2);
        }

        private async Task<bool> UpdateTaskAsync(string taskId, Task task)
        {
            var response = await client.PutAsJsonAsync("api/Task/" + taskId, task).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        private async Task<bool> DeleteTaskAsync(string taskId)
        {
            var response = await client.DeleteAsync("api/Task/" + taskId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}
