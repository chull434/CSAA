using CSAA.Models;
using Machine.Specifications;
using NSubstitute;
using Server.App_Data;
using Server.Areas.API;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Server.Controllers.ProjectControllerTests
{
    public class Context
    {
        public static IRepository<Project> Repository;
        public static IProjectService ProjectService;
        public static ProjectController ProjectController;

        Establish context = () =>
        {
            Repository = Substitute.For<IRepository<Project>>();
            ProjectService = Substitute.For<IProjectService>();
            ProjectController = new ProjectController(Repository, ProjectService);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectController : Context
    {
        static ProjectController projectController;

        Because of = () =>
        {
            projectController = new ProjectController(Repository, ProjectService);
        };

        It Constructs_ProjectService = () =>
        {
            projectController.ShouldNotBeNull();
        };
    }

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
}
