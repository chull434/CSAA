using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using Client.ViewModels;
using Machine.Specifications;
using NSubstitute;

namespace UnitTests.Client.ViewsModels.LoginViewModelTests
{
    public class Context
    {
        public static LoginViewModel ViewModel;
        public static IHttpClient HttpClient;
        public static IAccountRequest Request;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            Request = Substitute.For<IAccountRequest>();
            ViewModel = new LoginViewModel(Request);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_with_http_client : Context
    {
        static LoginViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new LoginViewModel(HttpClient);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_request : Context
    {
        static LoginViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new LoginViewModel(Request);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    #endregion

    #region Login Tests

    class when_I_call_Login : Context
    {
        Establish context = () =>
        {
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "password";
            Request.Login("testuser@localhost.com", "password").Returns("test");
        };

        Because of = () =>
        {
            ViewModel.Login.Execute(null);
        };

        It sends_a_register_request = () =>
        {
            Request.Received().Login("testuser@localhost.com", "password");
        };
    }

    class when_I_call_Login_no_Email : Context
    {
        Establish context = () =>
        {
            ViewModel.Email = "";
            ViewModel.Password = "password";
        };

        Because of = () =>
        {
            ViewModel.Login.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Login(Arg.Any<string>(), Arg.Any<string>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.EmailError.ShouldEqual("Please populate email field.");
        };
    }

    class when_I_call_Login_no_Password : Context
    {
        Establish context = () =>
        {
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "";
        };

        Because of = () =>
        {
            ViewModel.Login.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Login(Arg.Any<string>(), Arg.Any<string>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.PasswordError.ShouldEqual("Please enter you password.");
        };
    }

    #endregion
}
