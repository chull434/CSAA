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
    public class SprintTeamMemberService : ISprintTeamMemberService
    {
        private IRepository<SprintTeamMember> repository;
        private IRepository<Sprint> sprintRepository;
        private IRepository<ApplicationUser> userRepository;
        private IRepository<ProjectTeamMember> projectTeamMemberRepository;
        private IApplicationUserManager UserManager;
        private IEmailService EmailService;

        public SprintTeamMemberService(IRepository<SprintTeamMember> repository, IRepository<Sprint> sprintRepository, IRepository<ApplicationUser> userRepository, IRepository<ProjectTeamMember> projectTeamMemberRepository)
        {
            this.repository = repository;
            this.sprintRepository = sprintRepository;
            this.userRepository = userRepository;
            this.projectTeamMemberRepository = projectTeamMemberRepository;
            EmailService = new EmailService();
        }

        public SprintTeamMemberService(IRepository<SprintTeamMember> repository, IRepository<Sprint> sprintRepository, IApplicationUserManager UserManager, IRepository<ApplicationUser> userRepository, IRepository<ProjectTeamMember> projectTeamMemberRepository, IEmailService EmailService)
        {
            this.repository = repository;
            this.sprintRepository = sprintRepository;
            this.UserManager = UserManager;
            this.userRepository = userRepository;
            this.projectTeamMemberRepository = projectTeamMemberRepository;
            this.EmailService = EmailService;
        }

        public List<ServiceModel.SprintTeamMember> GetAllSprintTeamMembers()
        {
            var sprintTeamMembers = repository.GetAll().Select(m => m.Map()).ToList();
            return sprintTeamMembers;
        }

        public ServiceModel.SprintTeamMember GetSprintTeamMember(string sprintTeamMemberId)
        {
            var sprintTeamMember = repository.GetByID(sprintTeamMemberId).Map();
            return sprintTeamMember;
        }

        public void AddSprintTeamMember(string sprintId, string projectTeamMemberId)
        {
            var sprint = sprintRepository.GetByID(sprintId);
            var projectTeamMember = projectTeamMemberRepository.GetByID(projectTeamMemberId);
            var teamMember = new SprintTeamMember(sprint, projectTeamMember);
            sprint.SprintTeam.Add(teamMember);
            repository.Save();

            var user = UserManager.FindUserById(projectTeamMember.UserId);
            EmailService.SendEmail(user.Email, "KinguKongu Sprint Team Member Confirmation", "Hi " + user.UserName + ", You have been assigned to the following sprint: " + sprint.Title);
        }

        public void UpdateSprintTeamMember(string sprintTeamMemberId, ServiceModel.SprintTeamMember sprintTeamMember)
        {
            var dataSprintTeamMember = repository.GetByID(sprintTeamMemberId);
            repository.Save();
        }

        public void DeleteSprintTeamMember(string sprintTeamMemberId)
        {
            repository.Delete(sprintTeamMemberId);
            repository.Save();
        }

        public void SetApplicationUserManager(IApplicationUserManager applicationUserManager)
        {
            UserManager = applicationUserManager;
        }
    }
}