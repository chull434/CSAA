using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using Machine.Specifications;

namespace UnitTests.Client.AccountRequestsTest
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
        static AccountRequest accountRequest;

        Establish context = () => { };

        Because of = () =>
        {
            accountRequest = new AccountRequest();
        };

        It creates_a_accountRequest = () =>
        {
            accountRequest.ShouldNotBeNull();
        };
    }

    #endregion
}
