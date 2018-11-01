using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using CSAA.DataModels;
using CSAA.ServiceModels;
using Machine.Specifications;
using NSubstitute;
using Server;
using Server.App_Data;
using Server.Areas.API;
using Server.Models;
using Server.Services;

namespace UnitTests.Server.Controllers.ProjectTeamMemberControllerTests
{
    public class Context
    {
        public static IRepository<Project> ProjectRepository;
        public static IRepository<ProjectTeamMember> Repository;
        public static IProjectService ProjectService;
        public static IProjectTeamMemberService ProjectTeamMemberService;
        public static IApplicationUserManager ApplicationUserManager;
        public static ProjectTeamMemberController ProjectTeamMemberController;

        Establish context = () =>
        {
            Repository = Substitute.For<IRepository<ProjectTeamMember>>();
            ProjectRepository = Substitute.For<IRepository<Project>>();
            ProjectService = Substitute.For<IProjectService>();
            ProjectTeamMemberService = Substitute.For<IProjectTeamMemberService>();
            ProjectTeamMemberController = new ProjectTeamMemberController(Repository, ProjectTeamMemberService, ProjectRepository, ProjectService);
            ApplicationUserManager = Substitute.For<IApplicationUserManager>();
            ProjectTeamMemberController.UserManager = ApplicationUserManager;
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectTeamMemberController : Context
    {
        static ProjectTeamMemberController projectTeamMemberController;

        Because of = () =>
        {
            projectTeamMemberController = new ProjectTeamMemberController(Repository, ProjectTeamMemberService, ProjectRepository, ProjectService);
        };

        It constructs_project_team_member_controller = () =>
        {
            projectTeamMemberController.ShouldNotBeNull();
        };
    }

    #endregion

    #region Post Tests

    public class when_I_call_Post : Context
    {
        static AddTeamMember addTeamMember;
        static string userId;

        Establish context = () =>
        {
            addTeamMember = new AddTeamMember
            {
                email = "testuser@localhost.com",
                projectId = new Guid().ToString()
            };
            userId = new Guid().ToString();
            var user = new ApplicationUser
            {
                Id = userId
            };
            ApplicationUserManager.FindUserByEmail(addTeamMember.email).Returns(user);
        };

        Because of = () =>
        {
            ProjectTeamMemberController.Post(addTeamMember);
        };

        It adds_team_member = () =>
        {
            ProjectTeamMemberService.Received().AddTeamMember(Arg.Any<string>(), addTeamMember.projectId);
        };
    }

    #endregion
}
