using CSAA.DataModels;
using CSAA.Enums;
using Machine.Specifications;

namespace UnitTests.CSAA.DataModels.RoleAssignmentTests
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
        static RoleAssignment roleAssignment;

        Establish context = () =>
        {

        };

        Because of = () =>
        {
            roleAssignment = new RoleAssignment();
        };

        It creates_a_role_assignment = () =>
        {
            roleAssignment.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_role : Context
    {
        static RoleAssignment roleAssignment;
        static ProjectTeamMember projectTeamMember;

        Establish context = () =>
        {
            projectTeamMember = new ProjectTeamMember();
        };

        Because of = () =>
        {
            roleAssignment = new RoleAssignment(Role.Developer, projectTeamMember);
        };

        It creates_a_role_assignment = () =>
        {
            roleAssignment.ShouldNotBeNull();
        };
    }

    #endregion
}
