using ServiceModel =  CSAA.ServiceModels;
using CSAA.DataModels;
using Machine.Specifications;
using NSubstitute;
using Server;
using Server.App_Data;
using Server.Services;
using System;
using System.Collections.Generic;

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
            projectService = new ProjectService(Repository);
        };

        It Constructs_ProjectService = () =>
        {
            projectService.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_ProjectService_with_userManager : Context
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

    #region GetProjects() Tests

    public class when_I_call_GetProjects : Context
    {
        static List<ServiceModel.Project> result;

        Establish context = () =>
        {
            var projects = new List<Project> { new Project(), new Project(), new Project() };
            Repository.GetAll().Returns(projects);
        };

        Because of = () =>
        {
            result = ProjectService.GetProjects();
        };
            
        It returns_projects = () =>
        {
            result.Count.ShouldEqual(3);
        };
    }

    #endregion

    #region GetProject(string projectId, string userId) Tests

    public class when_I_call_GetProject : Context
    {
        static string id;
        static string userId;
        static ServiceModel.Project result;

        Establish context = () =>
        {
            id = new Guid().ToString();
            userId = new Guid().ToString();
            var project = new Project();
            Repository.GetByID(id).Returns(project);
        };

        Because of = () =>
        {
            result = ProjectService.GetProject(id, userId);
        };

        It returns_project = () =>
        {
            result.ShouldNotBeNull();
        };
    }

    #endregion

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
