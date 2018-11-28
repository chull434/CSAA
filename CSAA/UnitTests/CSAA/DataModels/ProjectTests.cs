using System;
using CSAA.DataModels;
using CSAA.Enums;
using ServiceModel = CSAA.ServiceModels;
using Machine.Specifications;

namespace UnitTests.CSAA.DataModels.ProjectTests
{
    public class Context
    {
        public static Project project;

        Establish context = () =>
        {
            project = new Project();
        };
    }

    #region Constructor Tests

    public class when_I_Construct : Context
    {
        static Project project;

        Establish context = () =>
        {

        };

        Because of = () =>
        {
            project = new Project();
        };

        It creates_a_project = () =>
        {
            project.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_title : Context
    {
        static Project project;

        Establish context = () =>
        {

        };

        Because of = () =>
        {
            project = new Project("My Project");
        };

        It creates_a_project = () =>
        {
            project.ShouldNotBeNull();
        };
    }

    #endregion

    #region Map() Tests

    public class when_I_call_Map : Context
    {
        static Project project;
        static ServiceModel.Project result;

        Establish context = () =>
        {
            project = new Project();
            project.ProjectTeam.Add(new ProjectTeamMember{ Project = new Project("test")});
        };

        Because of = () =>
        {
            result = project.Map();
        };

        It maps = () =>
        {
            result.ShouldNotBeNull();
        };
    }

    #endregion

    #region RoleAssigned(Role role) Tests

    class when_I_call_RoleAssigned_true : Context
    {
        static bool result;

        Establish context = () =>
        {
            var userId = new Guid().ToString();
            var member = new ProjectTeamMember(userId, project, Role.ProductOwner);
            project.ProjectTeam.Add(member);
        };

        Because of = () =>
        {
            result = project.RoleAssigned(Role.ProductOwner);
        };

        It returns_true = () =>
        {
            result.ShouldBeTrue();
        };
    }

    class when_I_call_RoleAssigned_false : Context
    {
        static bool result;

        Establish context = () =>
        {
            var userId = new Guid().ToString();
            var member = new ProjectTeamMember(userId, project, Role.ProjectManager);
            project.ProjectTeam.Add(member);
        };

        Because of = () =>
        {
            result = project.RoleAssigned(Role.ProductOwner);
        };

        It returns_false = () =>
        {
            result.ShouldBeFalse();
        };
    }

    #endregion
}
