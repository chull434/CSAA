using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Server.App_Data;
using Server.Models;

namespace Server.Services
{
    public class ProjectTeamMemberService : IProjectTeamMemberService
    {
        private IRepository<ProjectTeamMember> repository;
        private IRepository<Project> projectRepository;
        private IRepository<ApplicationUser> userRepository;
        private IApplicationUserManager UserManager;

        public ProjectTeamMemberService(IRepository<ProjectTeamMember> repository, IRepository<Project> projectRepository, IRepository<ApplicationUser> userRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
        }

        public ProjectTeamMemberService(IRepository<ProjectTeamMember> repository, IRepository<Project> projectRepository, IApplicationUserManager UserManager, IRepository<ApplicationUser> userRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
            this.UserManager = UserManager;
            this.userRepository = userRepository;
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
            dataProjectTeamMember.AddRole(projectTeamMember.Role);
            repository.Save();
        }

        public void DeleteProjectTeamMember(string projectTeamMemberId)
        {
            repository.Delete(projectTeamMemberId);
            repository.Save();
        }

        public void SetApplicationUserManager(IApplicationUserManager applicationUserManager)
        {
            UserManager = applicationUserManager;
        }

        public List<ServiceModel.User> SearchProjectTeamMembers(ServiceModel.User user)
        {
            var users = userRepository.GetAll().Where(u => u.Email == user.Email || u.UserName == user.Name || u.product_owner == user.product_owner || u.scrum_master == user.scrum_master || u.developer == user.developer).Select(u => u.Map()).ToList();
            return users;
        }
    }
}