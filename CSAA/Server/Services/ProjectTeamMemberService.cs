using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Server.App_Data;

namespace Server.Services
{
    public class ProjectTeamMemberService : IProjectTeamMemberService
    {
        private IRepository<ProjectTeamMember> repository;
        private IRepository<Project> projectRepository;
        private IApplicationUserManager UserManager;

        public ProjectTeamMemberService(IRepository<ProjectTeamMember> repository, IRepository<Project> projectRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
        }

        public ProjectTeamMemberService(IRepository<ProjectTeamMember> repository, IRepository<Project> projectRepository, IApplicationUserManager UserManager)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
            this.UserManager = UserManager;
        }

        public List<ServiceModel.ProjectTeamMember> GetAllProjectTeamMembers()
        {
            var projectTeamMembers = repository.GetAll().Select(m => m.Map()).ToList();
            foreach (var projectTeamMember in projectTeamMembers)
            {
                projectTeamMember.UserName = UserManager.GetUserNameById(projectTeamMember.UserId);
                projectTeamMember.UserEmail = UserManager.GetUserEmailById(projectTeamMember.UserId);
            }
            return projectTeamMembers;
        }

        public ServiceModel.ProjectTeamMember GetProjectTeamMember(string projectTeamMemberId)
        {
            var projectTeamMember = repository.GetByID(projectTeamMemberId).Map();
            projectTeamMember.UserName = UserManager.GetUserNameById(projectTeamMember.UserId);
            projectTeamMember.UserEmail = UserManager.GetUserEmailById(projectTeamMember.UserId);
            return projectTeamMember;
        }

        public void AddProjectTeamMember(string userId, string projectId)
        {
            var project = projectRepository.GetByID(projectId);
            var teamMember = new ProjectTeamMember(userId, project, Role.TeamMember);
            project.ProjectTeam.Add(teamMember);
            repository.Save();
        }

        public void UpdateProjectTeamMember(string projectTeamMemberId, ServiceModel.ProjectTeamMember projectTeamMember)
        {
            var dataProjectTeamMember = repository.GetByID(projectTeamMemberId);
            //dataProjectTeamMember.Role = projectTeamMember.Role;
            repository.Save();
        }

        public void DeleteProjectTeamMember(string projectTeamMemberId)
        {
            repository.Delete(projectTeamMemberId);
            repository.Save();
        }
    }
}