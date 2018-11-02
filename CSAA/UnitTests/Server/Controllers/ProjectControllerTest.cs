using Machine.Specifications;
using NSubstitute;
using Server.App_Data;
using Server.Areas.API;
using Server.Services;
using CSAA.ServiceModels;

namespace UnitTests.Server.Controllers.ProjectControllerTests
{
    public class Context
    {
        public static IProjectService ProjectService;
        public static ProjectController ProjectController;

        Establish context = () =>
        {
            ProjectService = Substitute.For<IProjectService>();
            ProjectController = new ProjectController(ProjectService);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectController : Context
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
