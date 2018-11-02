using ServiceModel =  CSAA.ServiceModels;
using CSAA.DataModels;
using Machine.Specifications;
using NSubstitute;
using Server;
using Server.App_Data;
using Server.Services;
using System;

namespace UnitTests.Server.Services.ProjectServiceTests
{
    public class Context
    {
        public static IRepository<Project> Repository;
        public static IApplicationUserManager ApplicationUserManager;
        public static ProjectService ProjectService;

        Establish context = () =>
        {
            Repository = Substitute.For<IRepository<Project>>();
            ApplicationUserManager = Substitute.For<IApplicationUserManager>();
            ProjectService = new ProjectService(Repository, ApplicationUserManager);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectService : Context
    {
        static ProjectService projectService;

        Because of = () =>
        {
            projectService = new ProjectService(Repository, ApplicationUserManager); 
        };

        It Constructs_ProjectService = () =>
        {
            projectService.ShouldNotBeNull(); 
        };
    }

    #endregion

    //#region GetAllProjects() Tests
    //public class when_I_call__GetAllProjects : Context
    //{
    //    static List<Project> result;
    //    Establish context = () =>
    //    {
    //        var issues = new List<Project> { new Project(), new Project(), new Project() };
    //        Repository.GetAll().Returns(issues);
    //    };
    //    Because of = () =>
    //        result = ProjectService.GetAllProjects();
    //    It returns_list_issues = () =>
    //        result.Count.ShouldEqual(3);
    //}
    //#endregion

    #region CreateProject() Tests

    public class when_I_call_CreateProject : Context
    {
        static ServiceModel.Project project;
        static string userId;

        Establish context = () =>
        {
            project = new ServiceModel.Project("My Project");
            userId = Guid.NewGuid().ToString();
        };

        Because of = () =>
        {
            ProjectService.CreateProject(project, userId);
        };

        It creates_project = () =>
        {
            Repository.Received().Insert(Arg.Any<Project>());
            Repository.Received().Save();
        };
    }

    #endregion
}
