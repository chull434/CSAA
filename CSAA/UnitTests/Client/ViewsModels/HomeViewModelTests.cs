using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using Client.ViewModels;
using CSAA.ServiceModels;
using Machine.Specifications;
using Newtonsoft.Json;
using NSubstitute;

namespace UnitTests.Client.ViewsModels.HomeViewModelTests
{
    public class Context
    {
        public static HomeViewModel ViewModel;
        public static IHttpClient HttpClient;
        public static IAccountRequest AccountRequest;
        public static IProjectRequest ProjectRequest;
        public static IProjectTeamMemberRequest ProjectTeamMemberRequest;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            AccountRequest = Substitute.For<IAccountRequest>();
            ProjectRequest = Substitute.For<IProjectRequest>();
            ProjectTeamMemberRequest = Substitute.For<IProjectTeamMemberRequest>();
            ViewModel = new HomeViewModel(HttpClient, AccountRequest, ProjectRequest, ProjectTeamMemberRequest);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_with_http_client : Context
    {
        static HomeViewModel viewModel;

        Establish context = () =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var projects = new List<Project>
            {
                new Project("My Project")
            };
            response.Content = new StringContent(JsonConvert.SerializeObject(projects));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/Project").Returns(response);

            var _response = new HttpResponseMessage(HttpStatusCode.OK);
            var projectTeamMembers = new List<ProjectTeamMember>
            {
                new ProjectTeamMember()
            };
            _response.Content = new StringContent(JsonConvert.SerializeObject(projectTeamMembers));
            _response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/ProjectTeamMember").Returns(_response);
        };

        Because of = () =>
        {
            viewModel = new HomeViewModel(HttpClient);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };

        It gets_all_projects = () =>
        {
            HttpClient.Received().GetAsync("api/Project");
        };

        It gets_all_project_team_members = () =>
        {
            HttpClient.Received().GetAsync("api/ProjectTeamMember");
        };
    }

    public class when_I_Construct_with_requests : Context
    {
        static HomeViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new HomeViewModel(HttpClient, AccountRequest, ProjectRequest, ProjectTeamMemberRequest);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };
    }

    #endregion

    #region Logout Tests

    public class when_I_call_Logout : Context
    {
        Establish context = () =>
        {

        };

        Because of = () =>
        {
            ViewModel.Logout.Execute(null);
        };

        It logs_out = () =>
        {
            AccountRequest.Received().Logout();
        };
    }

    #endregion

    #region Create Project Tests

    public class when_I_call_CreateProject : Context
    {
        Establish context = () =>
        {
            var projectId = Guid.NewGuid().ToString();
            ProjectRequest.CreateProject(Arg.Any<Project>()).Returns(projectId);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var project = new Project("My Project");
            response.Content = new StringContent(JsonConvert.SerializeObject(project));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/Project/" + projectId).Returns(response);
        };

        Because of = () =>
        {
            ViewModel.CreateProject.Execute(null);
        };

        It creates_a_project = () =>
        {
            ProjectRequest.Received().CreateProject(Arg.Any<Project>());
        };
    }

    #endregion
}
