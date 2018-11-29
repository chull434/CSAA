using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Server.App_Data;
using System.Collections.Generic;
using System.Linq;

namespace Server.Services
{
    public class SprintService : ISprintService
    {
        private IRepository<Sprint> repository;
        private IRepository<Project> projectRepository;
        private IApplicationUserManager UserManager;

        public SprintService(IRepository<Sprint> repository, IRepository<Project> projectRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
        }

        public SprintService(IRepository<Sprint> repository, IRepository<Project> projectRepository, IApplicationUserManager UserManager)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
            this.UserManager = UserManager;
        }

        public List<ServiceModel.Sprint> GetSprints()
        {
            var sprints = repository.GetAll().Select(p => p.Map()).ToList();
            return sprints;
        }

        public ServiceModel.Sprint GetSprint(string sprintId, string userId)
        {
            var sprint = repository.GetByID(sprintId).Map();
            return sprint;
        }

        public string CreateSprint(ServiceModel.Sprint sprint, string userId)
        {
            var project = projectRepository.GetByID(sprint.ProjectId);
            var dataSprint = new Sprint(sprint.Title, project, sprint.StartDate, sprint.EndDate);
            repository.Insert(dataSprint);
            repository.Save();
            return dataSprint.Id.ToString();
        }

        public void UpdateSprint(string sprintId, ServiceModel.Sprint sprint)
        {
            var dataSprint = repository.GetByID(sprintId);
            dataSprint.Title = sprint.Title;
            repository.Save();
        }

        public void DeleteSprint(string sprintId)
        {
            repository.Delete(sprintId);
            repository.Save();
        }

        public void SetApplicationUserManager(IApplicationUserManager applicationUserManager)
        {
            UserManager = applicationUserManager;
        }
    }
}