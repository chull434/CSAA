﻿using System;
using System.Collections.Generic;
using Client.Requests;
using CSAA.ServiceModels;
using Machine.Specifications;
using Newtonsoft.Json;
using NSubstitute;
using System.Net;
using System.Net.Http;

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
        static string result;
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
            result.ShouldEqual("");
        };
    }

    public class when_I_call_Register_with_error : Context
    {
        static string result;
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
            var anonymousErrorObject = new { message = "", ModelState = new Dictionary<string, string[]>() };
            anonymousErrorObject.ModelState.Add("", new string[] {"test", "test"});
            var json = JsonConvert.SerializeObject(anonymousErrorObject);
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent(json);
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.PostAsJsonAsync("api/Account/Register", user).Returns(response);
        };

        Because of = () =>
        {
            result = AccountRequest.Register(user);
        };

        It sends_a_register_request_and_returns_error = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/Account/Register", user);
            result.ShouldEqual("test test");
        };
    }

    #endregion

    #region Login Tests

    public class when_I_call_Login : Context
    {
        static string result;
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
            result.ShouldEqual("");
        };

        It receives_a_token_and_sets_it = () =>
        {
            HttpClient.Received().SetAuthorizationToken("test");
        };
    }

    public class when_I_call_Login_with_error : Context
    {
        static string result;
        static string email;
        static string password;

        Establish context = () =>
        {
            email = "testuser@localhost";
            password = "password";

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var loginErrorMessage = new LoginErrorMessage
            {
                error = "test",
                error_description = "test"
            };
            var json = JsonConvert.SerializeObject(loginErrorMessage);
            response.Content = new StringContent(json);
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.PostAsync("/token", Arg.Any<FormUrlEncodedContent>()).Returns(response);
        };

        Because of = () =>
        {
            result = AccountRequest.Login(email, password);
        };

        It sends_a_login_request_returns_error = () =>
        {
            HttpClient.Received().PostAsync("/token", Arg.Any<FormUrlEncodedContent>());
            result.ShouldEqual("test");
        };

        It does_not_receive_a_token_or_set_it = () =>
        {
            HttpClient.DidNotReceive().SetAuthorizationToken("test");
        };
    }

    #endregion

    #region Logout Tests

    public class when_i_log_out : Context
    {
        static string result;

        Establish context = () =>
        {           
            var response = new HttpResponseMessage(HttpStatusCode.OK);           
            HttpClient.PostAsync("api/Account/Logout", null).Returns(response);
        };

        Because of = () =>
        {
            result = AccountRequest.Logout();
        };

        It sends_a_logout_request = () =>
        {
            HttpClient.Received().PostAsync("api/Account/Logout", null);
            result.ShouldEqual("");
        };
   
    }

    #endregion
}
