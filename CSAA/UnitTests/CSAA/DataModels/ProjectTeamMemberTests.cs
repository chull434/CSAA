using System;
using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Machine.Specifications;

namespace UnitTests.CSAA.DataModels.ProjectTeamMemberTests
{
    public class Context
    {
        Establish context = () =>
        {

        };
    }

    #region Constructor Tests

    public class when_I_Construct_parameterless : Context
    {
        static ProjectTeamMember projectTeamMember;

        Establish context = () =>
        {

        };

        Because of = () =>
        {
            projectTeamMember = new ProjectTeamMember();
        };

        It creates_a_project_team_member = () =>
        {
            projectTeamMember.ShouldNotBeNull();
        };
    }

    public class when_I_Construct : Context
    {
        static ProjectTeamMember projectTeamMember;
        static string userId;
        static Project project;

        Establish context = () =>
        {
            userId = Guid.NewGuid().ToString();
            project = new Project("My Project");
        };

        Because of = () =>
        {
            projectTeamMember = new ProjectTeamMember(userId, project, Role.ProductOwner);
        };

        It creates_a_project_team_member = () =>
        {
            projectTeamMember.ShouldNotBeNull();
        };
    }

    #endregion

    #region Map() Tests

    public class when_I_call_Map : Context
    {
        static ProjectTeamMember projectTeamMember;
        static ServiceModel.ProjectTeamMember result;

        Establish context = () =>
        {
            projectTeamMember = new ProjectTeamMember();
            projectTeamMember.Project = new Project("test");
        };

        Because of = () =>
        {
            result = projectTeamMember.Map();
        };

        It maps = () =>
        {
            result.ShouldNotBeNull();
        };
    }

    #endregion
}
