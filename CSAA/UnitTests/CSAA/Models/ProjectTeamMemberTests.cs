using System;
using CSAA.Models;
using Machine.Specifications;

namespace UnitTests.CSAA.Models.ProjectTeamMemberTests
{
    public class Context
    {
        Establish context = () =>
        {

        };
    }

    #region Constructor Tests

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
}
