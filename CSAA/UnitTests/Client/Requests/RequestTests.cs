using Client.Requests;
using Machine.Specifications;
using NSubstitute;

namespace UnitTests.Client.Requests.RequestTests
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
    }

    public class when_I_Construct_with_HttpClient : Context
    {
        static Request request;
        static IHttpClient httpClient;

        Establish context = () =>
        {
            httpClient = Substitute.For<IHttpClient>();
        };

        Because of = () =>
        {
            request = new Request(httpClient);
        };

        It creates_a_request = () =>
        {
            request.ShouldNotBeNull();
        };
    }

    #endregion
}
