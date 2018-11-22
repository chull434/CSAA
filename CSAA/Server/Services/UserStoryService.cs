using CSAA.DataModels;
using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Services
{
    public class UserStoryService : IUserStoryService
    {
        private IRepository<UserStory> repository;
        private IRepository<Project> projectRepository;
        private IApplicationUserManager UserManager;

        public UserStoryService(IRepository<UserStory> repository, IRepository<Project> projectRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
        }

        public UserStoryService(IRepository<UserStory> repository, IApplicationUserManager UserManager, IRepository<Project> projectRepository)
        {
            this.repository = repository;
            this.UserManager = UserManager;
            this.projectRepository = projectRepository;
        }

        public List<ServiceModel.UserStory> GetAllUserStories()
        {
            return repository.GetAll().Select(u => u.Map()).ToList();
        }

        public ServiceModel.UserStory GetUserStory(string UserStoryId)
        {
            var userStory = repository.GetByID(UserStoryId).Map();
            return userStory;
        }

        public string CreateUserStory(ServiceModel.UserStory userStory)
        {
            var dataUserStory = new UserStory(userStory.Title, userStory.Description);
            dataUserStory.Project = projectRepository.GetByID(userStory.ProjectId);
            dataUserStory.ProjectId = dataUserStory.Project.Id;
            repository.Insert(dataUserStory);
            repository.Save();
            return dataUserStory.Id.ToString();
        }

        public void UpdateUserStory(string userStoryId, ServiceModel.UserStory userStory)
        {
            var dataUserStory = repository.GetByID(userStoryId);
            dataUserStory.Title = userStory.Title;
            dataUserStory.Description = userStory.Description;
            repository.Save();
        }

        public void DeleteUserStory(string userStoryId)
        {
            repository.Delete(userStoryId);
            repository.Save();
        }
    }
}