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

        public UserStoryService(IRepository<UserStory> repository, IRepository<Project> projectRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
        }

        public List<ServiceModel.UserStory> GetAllUserStories()
        {
            return repository.GetAll().Select(m => m.Map()).ToList();
        }

        public ServiceModel.UserStory GetUserStory(string UserStoryId)
        {
            return repository.GetByID(UserStoryId).Map();
        }

        public string CreateUserStory(ServiceModel.UserStory userStory)
        {
            var dataUserStory = new UserStory(userStory.Title, userStory.Description);
            dataUserStory.Project = projectRepository.GetByID(userStory.ProjectId);
            repository.Insert(dataUserStory);
            repository.Save();
            return dataUserStory.Id.ToString();
        }

        public void UpdateUserStory(string userStoryId, ServiceModel.UserStory userStory)
        {
            var dataUserStory = repository.GetByID(userStoryId);
            dataUserStory.Title = userStory.Title;
            dataUserStory.Description = userStory.Description;
            dataUserStory.StoryPoints = userStory.StoryPoints;
            repository.Save();
        }

        public void DeleteUserStory(string userStoryId)
        {
            repository.Delete(userStoryId);
            repository.Save();
        }
    }
}