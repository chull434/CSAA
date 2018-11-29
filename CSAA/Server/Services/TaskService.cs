using CSAA.DataModels;
using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Services
{
    public class TaskService : ITaskService
    {
        private IRepository<Task> repository;
        private IRepository<UserStory> userStoryRepository;

        public TaskService(IRepository<Task> repository, IRepository<UserStory> userStoryRepository)
        {
            this.repository = repository;
            this.userStoryRepository = userStoryRepository;
        }

        public List<ServiceModel.Task> GetAllTasks()
        {
            return repository.GetAll().Select(m => m.Map()).ToList();
        }

        public ServiceModel.Task GetTask(string TaskId)
        {
            return repository.GetByID(TaskId).Map();
        }

        public string CreateTask(ServiceModel.Task task)
        {
            var dataTask = new Task(task.Title, task.Description);
            dataTask.UserStory = userStoryRepository.GetByID(task.UserStoryId);
            repository.Insert(dataTask);
            repository.Save();
            return dataTask.Id.ToString();
        }

        public void UpdateTask(string taskId, ServiceModel.Task task)
        {
            var dataTask = repository.GetByID(taskId);
            dataTask.Title = task.Title;
            dataTask.Description = task.Description;
            dataTask.Completed = task.Completed;
            dataTask.EstimatedHours = task.EstimatedHours;
            dataTask.EstimatedHoursRemaining = task.EstimatedHoursRemaining;
            dataTask.HoursWorked = task.HoursWorked;
            dataTask.UserIdAssignedTo = task.UserIdAssignedTo;
            repository.Save();
        }

        public void DeleteTask(string taskId)
        {
            repository.Delete(taskId);
            repository.Save();
        }
    }
}