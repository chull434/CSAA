using System;
using System.Linq;
using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Machine.Specifications;
using NSubstitute;
using Server.App_Data;
using Server.Services;
using Microsoft.AspNet.Identity;
using Server;
using Server.Models;

namespace UnitTests.Server.Services.ProjectTeamMemberServiceTests
{
    public class Context
    {
        public static IRepository<ProjectTeamMember> Repository;
        public static IRepository<Project> ProjectRepository;
        public static IRepository<ApplicationUser> UserRepository;
        public static IApplicationUserManager UserManager;
        public static IEmailService EmailService;
        public static ProjectTeamMemberService Service;

        Establish context = () =>
        {
            Repository = Substitute.For<IRepository<ProjectTeamMember>>();
            ProjectRepository = Substitute.For<IRepository<Project>>();
            UserRepository = Substitute.For<IRepository<ApplicationUser>>();
            UserManager = Substitute.For<IApplicationUserManager>();
            EmailService = Substitute.For<IEmailService>();
            Service = new ProjectTeamMemberService(Repository, ProjectRepository, UserManager, UserRepository, EmailService);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectService : Context
    {
        static ProjectTeamMemberService projectTeamMemberService;

        Because of = () =>
        {
            projectTeamMemberService = new ProjectTeamMemberService(Repository, ProjectRepository, UserRepository);
        };

        It constructs_project_team_member_service = () =>
        {
            projectTeamMemberService.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_ProjectService_test : Context
    {
        static ProjectTeamMemberService projectTeamMemberService;

        Because of = () =>
        {
            projectTeamMemberService = new ProjectTeamMemberService(Repository, ProjectRepository, UserManager, UserRepository, EmailService);
        };

        It constructs_project_team_member_service = () =>
        {
            projectTeamMemberService.ShouldNotBeNull();
        };
    }

    #endregion

    #region AddTeamMember() Tests

    public class when_I_call_AddTeamMember : Context
    {
        static string userId;
        static string projectId;
        static Project project;

        Establish context = () =>
        {
            projectId = Guid.NewGuid().ToString();
            userId = Guid.NewGuid().ToString();
            project = new Project("My Title");
            ProjectRepository.GetByID(projectId).Returns(project);
            var user = new ApplicationUser();
            UserManager.FindUserById(userId).Returns(user);
        };

        Because of = () =>
        {
            Service.AddProjectTeamMember(userId, projectId, Role.TeamMember);
        };

        It adds_team_member_to_team = () =>
        {
            ProjectRepository.Received().GetByID(projectId);
            project.ProjectTeam.FirstOrDefault(m => m.UserId == userId).ShouldNotBeNull();
            Repository.Received().Save();
        };

        It sends_email_notification = () =>
        {
            UserManager.Received().FindUserById(userId);
            EmailService.Received().SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        };
    }

    #endregion

    #region GetProjectTeamMember() Tests

    public class when_I_call_GetProjectTeamMember : Context
    {
        static string projectTeamMemberId;
        static ProjectTeamMember dataProjectTeamMember;
        static ServiceModel.ProjectTeamMember result;

        Establish context = () =>
        {
            projectTeamMemberId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            dataProjectTeamMember = new ProjectTeamMember
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProjectId = Guid.NewGuid(),
                //Role = Role.Developer,
                Project = new Project("My Title")
            };
            Repository.GetByID(projectTeamMemberId).Returns(dataProjectTeamMember);
            UserManager.GetUserNameById(userId).Returns("Test User");
            UserManager.GetUserEmailById(userId).Returns("testuser@localhost.com");
        };

        Because of = () =>
        {
            result = Service.GetProjectTeamMember(projectTeamMemberId);
        };

        It get_a_project_team_member = () =>
        {
            result.ShouldNotBeNull();
        };
    }

    #endregion

    #region UpdateTeamMember() Tests

    public class when_I_call_UpdateTeamMember : Context
    {
        static string projectTeamMemberId;
        static ServiceModel.ProjectTeamMember projectTeamMember;
        static ProjectTeamMember dataProjectTeamMember;

        Establish context = () => 
        {
            projectTeamMemberId = Guid.NewGuid().ToString();
            projectTeamMember = new ServiceModel.ProjectTeamMember();
            projectTeamMember.Role = Role.Developer;
            dataProjectTeamMember = new ProjectTeamMember();
            //dataProjectTeamMember.Role = Role.TeamMember;
            Repository.GetByID(projectTeamMemberId).Returns(dataProjectTeamMember);
        };

        Because of = () =>
        {
            Service.UpdateProjectTeamMember(projectTeamMemberId, projectTeamMember);
        };

        It updates_project_team_member = () =>
        {
            //dataProjectTeamMember.Role.ShouldEqual(Role.Developer);
            Repository.Received().Save();
        };
    }

    #endregion

    #region DeleteTeamMember() Tests

    public class when_I_call_DeleteTeamMember : Context
    {
        static string projectTeamMemberId;
        static ProjectTeamMember dataProjectTeamMember;

        Establish context = () =>
        {
            projectTeamMemberId = Guid.NewGuid().ToString();
            dataProjectTeamMember = new ProjectTeamMember();
            Repository.GetByID(projectTeamMemberId).Returns(dataProjectTeamMember);
        };

        Because of = () =>
        {
            Service.DeleteProjectTeamMember(projectTeamMemberId);
        };

        It deletes_project_team_member = () =>
        {
            Repository.Delete(projectTeamMemberId);
            Repository.Received().Save();
        };
    }

    #endregion


}
