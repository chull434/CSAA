﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAA.Models;
using Machine.Specifications;
using NSubstitute;
using Server.App_Data;
using Server.Services;

namespace UnitTests.Server
{
    public class Context
    {
        public static IRepository<Project> Repository;
        public static ProjectService ProjectService;
        Establish context = () =>
        {
            Repository = Substitute.For<IRepository<Project>>();
            ProjectService = new ProjectService(Repository);
        };
    }

    #region Constructor Tests
    public class when_I_Construct_ProjectService : Context
    {
        static ProjectService projectService;
        Because of = () => projectService = new ProjectService(Repository);
        It Constructs_ProjectService = () => projectService.ShouldNotBeNull();
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

    #region CreateAProject() Tests
    public class when_I_call_CreateProject : Context
    {
        static Project project;

        Establish context = () =>
        {
            project = new Project();
        };

        Because of = () =>
        {
            ProjectService.CreateProject(project);
        };

        It creates_project = () =>
        {
            Repository.Received().Insert(project);
            Repository.Received().Save();
        };
    }
    #endregion
}
