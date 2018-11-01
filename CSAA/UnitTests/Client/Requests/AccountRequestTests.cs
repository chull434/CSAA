using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using Client.Requests;
using CSAA.ServiceModels;
using Machine.Specifications;
using Newtonsoft.Json;
using NSubstitute;

namespace UnitTests.Client.Requests.AccountRequestsTest
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

    #region Login Tests

    public class when_I_call_Login : Context
    {
        static bool result;
        static string email;
        static string password;

        Establish context = () =>
        {
            email = "testuser@localhost";
            password = "password";

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var loginData = new LoginData
            {
                access_token = "test",
                token_type = "Bearer",
                userName = email
            };
            var json = JsonConvert.SerializeObject(loginData);
            response.Content = new StringContent(json);
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.PostAsync("/token", Arg.Any<FormUrlEncodedContent>()).Returns(response);
        };

        Because of = () =>
        {
            result = AccountRequest.Login(email, password);
        };

        It sends_a_login_request = () =>
        {
            HttpClient.Received().PostAsync("/token", Arg.Any<FormUrlEncodedContent>());
            result.ShouldBeTrue();
        };

        It recieves_a_token_and_sets_it = () =>
        {
            HttpClient.Received().SetAuthorizationToken("test");
        };
    }

    #endregion
}
