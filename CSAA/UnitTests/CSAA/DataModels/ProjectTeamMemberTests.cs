using System;
using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Machine.Specifications;

namespace UnitTests.CSAA.DataModels.ProjectTeamMemberTests
{
    public class Context
    {
        public static ProjectTeamMember projectTeamMember;

        Establish context = () =>
        {
            projectTeamMember = new ProjectTeamMember();
            projectTeamMember.Project = new Project("test");
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
        static ServiceModel.ProjectTeamMember result;

        Establish context = () =>
        {
            projectTeamMember.AddRole(Role.Developer);
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

    #region AddRole(Role role) Tests

    class when_I_call_AddRole : Context
    {
        Establish context = () =>
        {

        };

        Because of = () =>
        {
            projectTeamMember.AddRole(Role.TeamMember);
        };

        It adds_role = () =>
        {
            projectTeamMember.RoleAssignments.Count.ShouldEqual(1);
        };
    }

    class when_I_call_AddRole_already_has_role : Context
    {
        Establish context = () =>
        {
            projectTeamMember.AddRole(Role.TeamMember);
        };

        Because of = () =>
        {
            projectTeamMember.AddRole(Role.TeamMember);
        };

        It does_not_add_duplicate_role = () =>
        {
            projectTeamMember.RoleAssignments.Count.ShouldEqual(1);
        };
    }

    class when_I_call_AddRole_project_manager : Context
    {
        Establish context = () =>
        {
            var userId = new Guid().ToString();
            var member = new ProjectTeamMember(userId, projectTeamMember.Project, Role.ProjectManager);
            projectTeamMember.Project.ProjectTeam.Add(member);
        };

        Because of = () =>
        {
            projectTeamMember.AddRole(Role.ProjectManager);
        };

        It does_not_add_role = () =>
        {
            projectTeamMember.RoleAssignments.Count.ShouldEqual(0);
        };
    }

    class when_I_call_AddRole_product_owner : Context
    {
        Establish context = () =>
        {
            var userId = new Guid().ToString();
            var member = new ProjectTeamMember(userId, projectTeamMember.Project, Role.ProductOwner);
            projectTeamMember.Project.ProjectTeam.Add(member);
        };

        Because of = () =>
        {
            projectTeamMember.AddRole(Role.ProductOwner);
        };

        It does_not_add_role = () =>
        {
            projectTeamMember.RoleAssignments.Count.ShouldEqual(0);
        };
    }

    #endregion

    #region HasRole(Role role) Tests

    class when_I_call_HasRole_true : Context
    {
        static bool result;

        Establish context = () =>
        {
            projectTeamMember.AddRole(Role.TeamMember);
        };

        Because of = () =>
        {
            result = projectTeamMember.HasRole(Role.TeamMember);
        };

        It returns_true = () =>
        {
            result.ShouldBeTrue();
        };
    }

    class when_I_call_HasRole_false : Context
    {
        static bool result;

        Establish context = () =>
        {
            projectTeamMember.AddRole(Role.ProductOwner);
        };

        Because of = () =>
        {
            result = projectTeamMember.HasRole(Role.TeamMember);
        };

        It returns_false = () =>
        {
            result.ShouldBeFalse();
        };
    }

    #endregion
}
