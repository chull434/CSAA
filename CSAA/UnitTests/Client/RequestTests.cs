using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using Machine.Specifications;

namespace UnitTests.Client.RequestTests
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
        static Request request;

        Establish context = () => { };

        Because of = () =>
        {
            request = new Request();
        };

        It creates_a_request = () =>
        {
            request.ShouldNotBeNull();
        };

        //It creates_a_client = () => // testing private stuff?
        //{
        //    request.client.ShouldNotBeNull();
        //};
    }

    #endregion
}
