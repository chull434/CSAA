using System;
using System.Collections.Generic;
using Machine.Specifications;
using NSubstitute;
using Server.App_Data;
using Server.Areas.API;
using Server.Services;
using CSAA.ServiceModels;
using Server;

namespace UnitTests.Server.Controllers.ProjectControllerTests
{
    public class Context
    {
        public static IProjectService ProjectService;
        public static IApplicationUserManager ApplicationUserManager;
        public static ProjectController ProjectController;

        Establish context = () =>
        {
            ProjectService = Substitute.For<IProjectService>();
            ApplicationUserManager = Substitute.For<IApplicationUserManager>();
            ProjectController = new ProjectController(ProjectService);
            ProjectController.UserManager = ApplicationUserManager;
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectController : Context
    {
        static ProjectController projectController;

        Because of = () =>
        {
            projectController = new ProjectController();
        };

        It Constructs_ProjectService = () =>
        {
            projectController.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_ProjectController_with_service : Context
    {
        static ProjectController projectController;

        Because of = () =>
        {
            projectController = new ProjectController(ProjectService);
        };

        It Constructs_ProjectService = () =>
        {
            projectController.ShouldNotBeNull();
        };
    }

    #endregion

    #region Get Tests

    public class when_I_call_Get : Context
    {
        static List<Project> result;

        Establish context = () =>
        {
            ProjectService.GetProjects(Arg.Any<string>()).Returns(new List<Project>());
        };

        Because of = () =>
        {
            result = ProjectController.Get();
        };

        It returns_list_of_projects = () =>
        {
            result.ShouldNotBeNull();
            ProjectService.Received().GetProjects(Arg.Any<string>());
        };
    };

    public class when_I_call_Get_with_id : Context
    {
        static Project result;
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
            ProjectService.GetProject(id, Arg.Any<string>()).Returns(new Project());
        };

        Because of = () =>
        {
            result = ProjectController.Get(id);
        };

        It returns_project = () =>
        {
            result.ShouldNotBeNull();
            ProjectService.Received().GetProject(id, Arg.Any<string>());
        };
    };

    #endregion

    #region Post Tests

    public class when_I_call_Post : Context
    {
        static Project project;

        Establish context = () =>
        {
            project = new Project("My Project");
        };

        Because of = () =>
        {
            ProjectController.Post(project);
        };

        It creates_project = () =>
        {
            ProjectService.Received().CreateProject(project, Arg.Any<string>());
        };
    }

    #endregion

    #region Put Tests

    public class when_I_call_Put : Context
    {
        static string id; 
        static Project project;

        Establish context = () =>
        {
            id = new Guid().ToString();
            project = new Project("My Project");
        };

        Because of = () =>
        {
            ProjectController.Put(id, project);
        };

        It updates_project = () =>
        {
            ProjectService.Received().UpdateProject(id, project);
        };
    }

    #endregion

    #region Delete Tests

    public class when_I_call_Delete : Context
    {
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
        };

        Because of = () =>
        {
            ProjectController.Delete(id);
        };

        It updates_project = () =>
        {
            ProjectService.Received().DeleteProject(id);
        };
    }

    #endregion
}
