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

        public void AddProjectTeamMember(string userId, string projectId, Role role)
        {
            var project = projectRepository.GetByID(projectId);
            var teamMember = new ProjectTeamMember(userId, project, role);
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

        public List<ServiceModel.User> SearchProjectTeamMembers(string projectId, ServiceModel.User user)
        {
            var users = userRepository.GetAll();
            var project = projectRepository.GetByID(projectId);

            users = users.Where(u => project.ProjectTeam.FirstOrDefault(m => m.UserId == u.Id) == null).ToList();

            if(!string.IsNullOrEmpty(user.Email)) users = users.Where(u => u.Email.Contains(user.Email)).ToList();
            if(!string.IsNullOrEmpty(user.Name))  users = users.Where(u => u.UserName.Contains(user.Name)).ToList();
            if(user.product_owner)                users = users.Where(u => u.product_owner == user.product_owner).ToList();
            if(user.scrum_master)                 users = users.Where(u => u.scrum_master == user.scrum_master).ToList();
            if(user.developer)                    users = users.Where(u => u.developer == user.developer).ToList();

            return users.Select(u => u.Map()).ToList();
        }
    }
}