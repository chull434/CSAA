using CSAA.ServiceModels;
using Machine.Specifications;

namespace UnitTests.CSAA.ServiceModels.ProjectTeamMemberTests
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

    #endregion
}
