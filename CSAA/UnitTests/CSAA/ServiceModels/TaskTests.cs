using Machine.Specifications;
using CSAA.ServiceModels;

namespace UnitTests.CSAA.ServiceModels.TaskTests
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
        static Task task;

        Establish context = () =>
        {

        };

        Because of = () =>
        {
            task = new Task();
        };

        It creates_a_task = () =>
        {
            task.ShouldNotBeNull();
        };
    }

    #endregion
}
