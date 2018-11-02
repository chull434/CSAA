using Client.Requests;
using Client.ViewModels;
using Machine.Specifications;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using CSAA.ServiceModels;
using Newtonsoft.Json;

namespace UnitTests.Client.ViewsModels.ProjectViewModelTests
{
    public class Context
    {
        public static ProjectViewModel ViewModel;
        public static IHttpClient HttpClient;
        public static IAccountRequest Request;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            Request = Substitute.For<IAccountRequest>();
            ViewModel = new ProjectViewModel(Request);
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
        static string projectId;

        Establish context = () =>
        {
            projectId = Guid.NewGuid().ToString();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var project = new Project("My Project");
            response.Content = new StringContent(JsonConvert.SerializeObject(project));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/Project/" + projectId).Returns(response);
        };

        Because of = () =>
        {
            viewModel = new ProjectViewModel(HttpClient, projectId);
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
            viewModel = new ProjectViewModel(Request);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    #endregion
}
