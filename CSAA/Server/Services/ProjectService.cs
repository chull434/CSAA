﻿using CSAA.DataModels;
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

        public List<ServiceModel.Project> GetProjects(IApplicationUserManager UserManager)
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

        public ServiceModel.Project GetProject(string projectId, string userId, IApplicationUserManager UserManager)
        {
            var project = repository.GetByID(projectId).Map();
            foreach (var projectTeamMember in project.ProjectTeam)
            {
                projectTeamMember.UserName = UserManager.GetUserNameById(projectTeamMember.UserId);
                projectTeamMember.UserEmail = UserManager.GetUserEmailById(projectTeamMember.UserId);
            }
            project.IsProjectManager = project.ProjectTeam.FirstOrDefault(m => m.UserId == userId).Roles.Contains(Role.ProjectManager);
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