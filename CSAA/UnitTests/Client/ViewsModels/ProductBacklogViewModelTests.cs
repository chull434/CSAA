using Client.Requests;
using Client.ViewModels;
using Machine.Specifications;
using NSubstitute;
using System;
using System.Net;
using System.Net.Http;
using CSAA.ServiceModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTests.Client.ViewsModels.ProductBacklogViewModelTests
{
    public class Context
    {
        public static ProductBacklogViewModel ViewModel;
        public static IHttpClient HttpClient;
        public static IAccountRequest AccountRequest;
        public static IUserStoryRequest UserStoryRequest;
        public static IProjectRequest ProjectRequest;
        public static string Id;
        public static string usersStoryId;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            AccountRequest = Substitute.For<IAccountRequest>();
            UserStoryRequest = Substitute.For<IUserStoryRequest>();
            ProjectRequest = Substitute.For<IProjectRequest>();
            Id = new Guid().ToString();
            usersStoryId = new Guid().ToString();
            ViewModel = new ProductBacklogViewModel(HttpClient, AccountRequest, UserStoryRequest, ProjectRequest, Id);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_with_http_client : Context
    {
        static ProductBacklogViewModel viewModel;

        Establish context = () =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var project = new Project("My Project");
            response.Content = new StringContent(JsonConvert.SerializeObject(project));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/Project/" + Id).Returns(response);

            var response1 = new HttpResponseMessage(HttpStatusCode.OK);
            var userStories = new List<UserStory>
            {
                new UserStory("My User Story", "My Description...", Id)
            };
            response1.Content = new StringContent(JsonConvert.SerializeObject(userStories));
            response1.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/UserStory").Returns(response1);
        };

        Because of = () =>
        {
            viewModel = new ProductBacklogViewModel(HttpClient, Id);
        };

        It creates_a_viewModel = () =>
        {
            viewModel.ShouldNotBeNull();
        };

        It gets_project = () =>
        {
            HttpClient.Received().GetAsync("api/Project/" + Id);
        };

        It gets_all_UserStories = () =>
        {
            HttpClient.Received().GetAsync("api/UserStory");
        };
    }

    public class when_I_Construct_with_request : Context
    {
        static ProductBacklogViewModel viewModel;

        Establish context = () => { };

        Because of = () =>
        {
            viewModel = new ProductBacklogViewModel(HttpClient, AccountRequest, UserStoryRequest, ProjectRequest, Id);
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

    #region New User Story

    public class when_I_call_NewUserStory : Context
    {
        Establish context = () =>
        {
            UserStoryRequest.CreateUserStory(Arg.Any<UserStory>()).Returns(usersStoryId);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var userStory = new UserStory("My User Story", "My Description...", Id);
            response.Content = new StringContent(JsonConvert.SerializeObject(userStory));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/UserStory/" + usersStoryId).Returns(response);
        };

        Because of = () =>
        {
            ViewModel.NewUserStory.Execute(null);
        };

        It creates_a_new_user_story = () =>
        {
            UserStoryRequest.Received().CreateUserStory(Arg.Any<UserStory>());
        };

        It gets_user_story = () =>
        {
            HttpClient.Received().GetAsync("api/UserStory/" + usersStoryId);
        };
    }

    #endregion
}
