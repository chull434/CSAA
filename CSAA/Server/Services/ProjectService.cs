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
            var projects = repository.GetAll().Select(p => p.Map()).ToList();
            foreach (var project in projects)
            {
                foreach (var projectTeamMember in project.ProjectTeam)
                {
                    projectTeamMember.UserName = UserManager.GetUserNameById(projectTeamMember.UserId);
                    projectTeamMember.UserEmail = UserManager.GetUserEmailById(projectTeamMember.UserId);
                }
            }
            return projects;
        }

        public ServiceModel.Project GetProject(string projectId, string userId)
        {
            var project = repository.GetByID(projectId).Map();
            foreach (var projectTeamMember in project.ProjectTeam)
            {
                projectTeamMember.UserName = UserManager.GetUserNameById(projectTeamMember.UserId);
                projectTeamMember.UserEmail = UserManager.GetUserEmailById(projectTeamMember.UserId);
            }
            var member = repository.GetByID(projectId).ProjectTeam.FirstOrDefault(m => m.UserId == userId);
            if (member != null)
            {
                project.IsProjectManager = member.HasRole(Role.ProjectManager);
                project.IsProductOwner = member.HasRole(Role.ProductOwner);
                project.IsScrumMaster = member.HasRole(Role.ScrumMaster);
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

        public void SetApplicationUserManager(IApplicationUserManager applicationUserManager)
        {
            UserManager = applicationUserManager;
        }
    }
}