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
        public static IAccountRequest AccountRequest;
        public static IProjectRequest ProjectRequest;
        public static IProjectTeamMemberRequest ProjectTeamMemberRequest;
        public static string Id;

        Establish context = () =>
        {
            Id = new Guid().ToString();
            HttpClient = Substitute.For<IHttpClient>();
            AccountRequest = Substitute.For<IAccountRequest>();
            ProjectRequest = Substitute.For<IProjectRequest>();
            ProjectTeamMemberRequest = Substitute.For<IProjectTeamMemberRequest>();
            ViewModel = new ProjectViewModel(AccountRequest, ProjectRequest, ProjectTeamMemberRequest, Id);
        };
    }

    #region Constructor Tests

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

        It gets_project = () =>
        {
            HttpClient.Received().GetAsync("api/Project/" + projectId);
        };
    }

    public class when_I_Construct_with_request : Context
    {
        static ProjectViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new ProjectViewModel(AccountRequest, ProjectRequest, ProjectTeamMemberRequest, Id);
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

    #region Save Project Tests

    public class when_I_call_SaveProject : Context
    {
        Establish context = () =>
        {
            ProjectRequest.GetProject(Id).Returns(new Project("test"));
        };

        Because of = () =>
        {
            ViewModel.SaveProject.Execute(null);
        };

        It saves_the_project = () =>
        {
            ProjectRequest.Received().UpdateProject(Id, Arg.Any<Project>());
            ProjectRequest.Received().GetProject(Id);
        };
    }

    #endregion

    #region Add Team Member Tests

    public class when_I_call_AddTeamMember : Context
    {
        Establish context = () =>
        {
            ProjectRequest.GetProject(Id).Returns(new Project("test"));
        };

        Because of = () =>
        {
            ViewModel.AddTeamMember.Execute(null);
        };

        It adds_team_member_to_project = () =>
        {
            ProjectTeamMemberRequest.Received().AddProjectTeamMember(Arg.Any<string>(), Id);
            ProjectRequest.Received().GetProject(Id);
        };
    }

    #endregion

    #region OnProjectTeamMemberRoleChange(ProjectTeamMember projectTeamMember)

    public class when_I_call_OnProjectTeamMemberRoleChange : Context
    {
        static ProjectTeamMember projectTeamMember;

        Establish context = () =>
        {
            ProjectRequest.GetProject(Id).Returns(new Project("test"));
            projectTeamMember = new ProjectTeamMember();
        };

        Because of = () =>
        {
            ViewModel.OnProjectTeamMemberRoleChange(projectTeamMember);
        };

        It updates_role = () =>
        {
            ProjectTeamMemberRequest.Received().UpdateProjectTeamMember(projectTeamMember.Id, projectTeamMember);
        };

        It gets_project = () =>
        {
            ProjectRequest.Received().GetProject(Id);
        };
    }

    #endregion

}
