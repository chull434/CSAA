using Client.Requests;
using Client.ViewModels;
using Machine.Specifications;
using NSubstitute;
using System;

namespace UnitTests.Client.ViewsModels.ProjectViewModelTests
{
    public class Context
    {
        public static ProjectViewModel ViewModel;
        public static IHttpClient HttpClient;
        public static IAccountRequest Request;
        public static string projectId;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            Request = Substitute.For<IAccountRequest>();
            projectId = new Guid() + "/";
            ViewModel = new ProjectViewModel(Request, projectId);
        };
    }

    #region Constructor Tests

    public class when_I_Construct : Context
    {
        static ProjectViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new ProjectViewModel();
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_http_client : Context
    {
        static ProjectViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            //viewModel = new ProjectViewModel(HttpClient);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    public class when_I_Construct_with_request : Context
    {
        static ProjectViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            //viewModel = new ProjectViewModel(Request);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    #endregion
}
