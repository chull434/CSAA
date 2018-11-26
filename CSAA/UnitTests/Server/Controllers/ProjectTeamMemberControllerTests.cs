using CSAA.ServiceModels;
using Machine.Specifications;
using NSubstitute;
using Server;
using Server.Areas.API;
using Server.Models;
using Server.Services;
using System;

namespace UnitTests.Server.Controllers.ProjectTeamMemberControllerTests
{
    public class Context
    {
        public static IProjectTeamMemberService Service;
        public static IApplicationUserManager ApplicationUserManager;
        public static ProjectTeamMemberController ProjectTeamMemberController;

        Establish context = () =>
        {
            Service = Substitute.For<IProjectTeamMemberService>();
            ProjectTeamMemberController = new ProjectTeamMemberController(Service);
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
            projectTeamMemberController = new ProjectTeamMemberController();
        };

        It constructs_project_team_member_controller = () =>
        {
            projectTeamMemberController.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_ProjectTeamMemberController_with_service : Context
    {
        static ProjectTeamMemberController projectTeamMemberController;

        Because of = () =>
        {
            projectTeamMemberController = new ProjectTeamMemberController(Service);
        };

        It constructs_project_team_member_controller = () =>
        {
            projectTeamMemberController.ShouldNotBeNull();
        };
    }

    #endregion

    #region Gets Tests

    public class when_I_call_Get : Context
    {
        Establish context = () =>
        {
            
        };

        Because of = () =>
        {
            ProjectTeamMemberController.Get();
        };

        It gets_team_members = () =>
        {
            Service.Received().GetAllProjectTeamMembers();
        };
    }

    public class when_I_call_Get_by_id : Context
    {
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
        };

        Because of = () =>
        {
            ProjectTeamMemberController.Get(id);
        };

        It gets_team_member = () =>
        {
            Service.Received().GetProjectTeamMember(id);
        };
    }

    #endregion

    #region Post Tests

    public class when_I_call_Post : Context
    {
        static ProjectTeamMember projectTeamMember;
        static string userId;

        Establish context = () =>
        {
            projectTeamMember = new ProjectTeamMember
            {
                UserEmail = "testuser@localhost.com",
                ProjectId = new Guid().ToString()
            };
            userId = new Guid().ToString();
            var user = new ApplicationUser
            {
                Id = userId
            };
            ApplicationUserManager.FindUserByEmail(projectTeamMember.UserEmail).Returns(user);
        };

        Because of = () =>
        {
            ProjectTeamMemberController.Post(projectTeamMember);
        };

        It adds_team_member = () =>
        {
            Service.Received().AddProjectTeamMember(userId, projectTeamMember.ProjectId);
        };
    }

    #endregion

    #region Put Tests

    public class when_I_call_Put : Context
    {
        static string id;
        static ProjectTeamMember projectTeamMember;

        Establish context = () =>
        {
            id = new Guid().ToString();
            projectTeamMember = new ProjectTeamMember
            {
                UserEmail = "testuser@localhost.com",
                ProjectId = new Guid().ToString()
            };

        };

        Because of = () =>
        {
            ProjectTeamMemberController.Put(id, projectTeamMember);
        };

        It updates_team_member = () =>
        {
            Service.Received().UpdateProjectTeamMember(id, projectTeamMember);
        };
    }

    #endregion

    #region Delete Tests

    public class when_I_call_Delete: Context
    {
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
        };

        Because of = () =>
        {
            ProjectTeamMemberController.Delete(id);
        };

        It deletes_team_member = () =>
        {
            Service.Received().DeleteProjectTeamMember(id);
        };
    }

    #endregion
}
