using Client.Requests;
using Client.ViewModels;
using CSAA.Models;
using Machine.Specifications;
using NSubstitute;

namespace UnitTests.Client.ViewsModels.RegistrationViewModelTests
{
    public class Context
    {
        public static RegistrationViewModel ViewModel;
        public static IHttpClient HttpClient;
        public static IAccountRequest Request;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            Request = Substitute.For<IAccountRequest>();
            ViewModel = new RegistrationViewModel(Request);
        };
    }

    #region Constructor Tests

    public class when_I_Construct : Context
    {
        static RegistrationViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new RegistrationViewModel();
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_http_client : Context
    {
        static RegistrationViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new RegistrationViewModel(HttpClient);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_request : Context
    {
        static RegistrationViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new RegistrationViewModel(Request);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    #endregion

    #region Register Tests

    class when_I_call_Register : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "Test";
            ViewModel.Surname = "User";
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "password";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It sends_a_register_request = () =>
        {
            Request.Received().Register(Arg.Any<User>());
        };
    }

    class when_I_call_Register_no_FirstName : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "";
            ViewModel.Surname = "User";
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "password";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Register(Arg.Any<User>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.FieldsError.ShouldEqual("Please populate all fields.");
        };
    }

    class when_I_call_Register_no_Surname : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "Test";
            ViewModel.Surname = "";
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "password";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Register(Arg.Any<User>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.FieldsError.ShouldEqual("Please populate all fields.");
        };
    }

    class when_I_call_Register_no_Email : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "Test";
            ViewModel.Surname = "User";
            ViewModel.Email = "";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "password";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Register(Arg.Any<User>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.FieldsError.ShouldEqual("Please populate all fields.");
        };
    }

    class when_I_call_Register_invalid_Email : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "Test";
            ViewModel.Surname = "User";
            ViewModel.Email = "testuser@localhost";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "password";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Register(Arg.Any<User>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.FieldsError.ShouldEqual("Invalid email.");
        };
    }

    class when_I_call_Register_empty_confirm_password : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "Test";
            ViewModel.Surname = "User";
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Register(Arg.Any<User>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.PasswordError.ShouldEqual("Passwords do not match.");
        };
    }

    class when_I_call_Register_mismatch_confirm_password : Context
    {
        Establish context = () =>
        {
            ViewModel.FirstName = "Test";
            ViewModel.Surname = "User";
            ViewModel.Email = "testuser@localhost.com";
            ViewModel.Password = "password";
            ViewModel.ConfirmPassword = "Pa$$w0rd";
        };

        Because of = () =>
        {
            ViewModel.Register.Execute(null);
        };

        It does_not_send_a_register_request = () =>
        {
            Request.DidNotReceive().Register(Arg.Any<User>());
        };

        It sets_error_message_label = () =>
        {
            ViewModel.PasswordError.ShouldEqual("Passwords do not match.");
        };
    }

    #endregion
}
