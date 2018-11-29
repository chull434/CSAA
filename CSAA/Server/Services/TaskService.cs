using CSAA.DataModels;
using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.Enums;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Services
{
    public class TaskService : ITaskService
    {
        private IRepository<Task> repository;
        private IRepository<UserStory> userStoryRepository;
        private IRepository<Project> projectRepository;
        private IRepository<Sprint> sprintRepository;

        public TaskService(IRepository<Task> repository, IRepository<UserStory> userStoryRepository, IRepository<Project> projectRepository, IRepository<Sprint> sprintRepository)
        {
            this.repository = repository;
            this.userStoryRepository = userStoryRepository;
            this.projectRepository = projectRepository;
            this.sprintRepository = sprintRepository;
        }

        public List<ServiceModel.Task> GetAllTasks()
        {
            return repository.GetAll().Select(m => m.Map()).ToList();
        }

        public ServiceModel.Task GetTask(string TaskId, string userId)
        {
            var task = repository.GetByID(TaskId).Map();
            var userStory = userStoryRepository.GetByID(task.UserStoryId).Map();
            if (userStory.SprintId != null)
            {
                var member = projectRepository.GetByID(userStory.ProjectId).ProjectTeam.FirstOrDefault(m => m.UserId == userId);
                if (member != null && (member.HasRole(Role.ScrumMaster) || member.HasRole(Role.Developer)))
                {
                    var sprint = sprintRepository.GetByID(userStory.SprintId);
                    task.InSprintTeam = sprint.SprintTeam.FirstOrDefault(m => m.ProjectTeamMemberId == member.Id) != null;
                }
            }
            return task;
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