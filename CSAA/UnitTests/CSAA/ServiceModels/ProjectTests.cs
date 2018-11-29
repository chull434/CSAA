using CSAA.ServiceModels;
using Machine.Specifications;

namespace UnitTests.CSAA.ServiceModels.ProjectTests
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
}
