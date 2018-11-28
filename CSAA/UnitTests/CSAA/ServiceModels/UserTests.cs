using CSAA.ServiceModels;
using Machine.Specifications;

namespace UnitTests.CSAA.ServiceModels.UserTests
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
        static User user;

        Establish context = () =>
        {

        };

        Because of = () =>
        {
            user = new User();
        };

        It creates_a_user = () =>
        {
            user.ShouldNotBeNull();
        };
    }

    #endregion
}
