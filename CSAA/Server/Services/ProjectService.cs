using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Server.App_Data;
using System.Collections.Generic;
using System.Linq;

namespace Server.Services
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> repository;
        private IApplicationUserManager UserManager;

        public ProjectService(IRepository<Project> repository)
        {
            this.repository = repository;
        }

        public ProjectService(IRepository<Project> repository, IApplicationUserManager UserManager)
        {
            this.repository = repository;
            this.UserManager = UserManager;
        }

        public List<ServiceModel.Project> GetProjects()
        {
            var dataProjects = repository.GetAll();
            var projects = new List<ServiceModel.Project>();
            foreach (var dataProject in dataProjects)
            {
                var project = dataProject.Map();
                projects.Add(project);
            }
            return projects;
        }

        public ServiceModel.Project GetProject(string projectId)
        {
            var dataProject = repository.GetByID(projectId);
            var project = dataProject.Map();
            foreach (var projectTeamMember in dataProject.ProjectTeam)
            {
                var member = projectTeamMember.Map();
                member.UserName = UserManager.GetUserNameById(projectTeamMember.UserId);
                project.ProjectTeam.Add(member);
            }
            return project;
        }

        public string CreateProject(ServiceModel.Project project, string userId)
        {
            var dataProject = new Project(project.Title);
            var member = new ProjectTeamMember(userId, dataProject, Role.ProjectManager);
            dataProject.ProjectTeam.Add(member);
            repository.Insert(dataProject);
            repository.Save();
            return dataProject.Id.ToString();
        }

        public void UpdateProject(string projectId, ServiceModel.Project project)
        {
            var dataProject = repository.GetByID(projectId);
            dataProject.Title = project.Title;
            repository.Save();
        }

        public void DeleteProject(string projectId)
        {
            repository.Delete(projectId);
            repository.Save();
        }
    }
}