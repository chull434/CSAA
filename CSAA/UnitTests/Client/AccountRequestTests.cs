using System.Net;
using System.Net.Http;
using Client.Requests;
using CSAA.Models;
using Machine.Specifications;
using NSubstitute;

namespace UnitTests.Client.AccountRequestsTest
{
    public class Context
    {
        public static AccountRequest AccountRequest;
        public static IHttpClient HttpClient;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            AccountRequest = new AccountRequest(HttpClient);
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

    public class when_I_Construct_with_HttpClient : Context
    {
        static AccountRequest accountRequest;

        Establish context = () => { };

        Because of = () =>
        {
            accountRequest = new AccountRequest(HttpClient);
        };

        It creates_a_accountRequest = () =>
        {
            accountRequest.ShouldNotBeNull();
        };
    }

    #endregion

    #region Register Tests

    public class when_I_call_Register : Context
    {
        static bool result;
        static User user;

        Establish context = () =>
        {
            user = new User
            {
                Name = "Test User",
                Email = "testuser@localhost",
                Password = "password",
                product_owner = true,
                scrum_master = true,
                developer = true
            };
            HttpClient.PostAsJsonAsync("api/Account/Register", user).Returns(new HttpResponseMessage(HttpStatusCode.OK));
        };

        Because of = () =>
        {
            result = AccountRequest.Register(user);
        };

        It sends_a_register_request = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/Account/Register", user);
            result.ShouldBeTrue();
        };
    }

    #endregion
}
