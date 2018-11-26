using System;
using Client.Requests;
using CSAA.ServiceModels;
using Machine.Specifications;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnitTests.Client.Requests.ProjectRequestTests
{
    public class Context
    {
        public static ProjectRequest ProjectRequest;
        public static IHttpClient HttpClient;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            ProjectRequest = new ProjectRequest(HttpClient);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_with_HttpClient : Context
    {
        static ProjectRequest projectRequest;

        Establish context = () => { };

        Because of = () =>
        {
            projectRequest = new ProjectRequest(HttpClient);
        };

        It creates_a_accountRequest = () =>
        {
            projectRequest.ShouldNotBeNull();
        };
    }

    #endregion

    #region GetProjects() Tests

    public class when_I_GetProjects : Context
    {
        static List<Project> result;

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
        };

        Because of = () =>
        {
           result = ProjectRequest.GetProjects();
        };

        It returns_list_of_projects = () =>
        {
            HttpClient.Received().GetAsync("api/Project");
            result.Count.ShouldEqual(1);
        };
    }

    #endregion

    #region GetProject(string projectId)

    public class when_I_GetProject : Context
    {
        static Project result;
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(new Project("My Project")));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/Project/" + id).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectRequest.GetProject(id);
        };

        It returns_a_project = () =>
        {
            HttpClient.Received().GetAsync("api/Project/" + id);
            result.ShouldNotBeNull();
        };
    }

    #endregion

    #region CreateProject(Project project) Tests

    public class when_I_call_CreateProject : Context
    {
        static string result;
        static Project project;
        static string projectId;

        Establish context = () =>
        {
            project = new Project("MyTitle");
            projectId = "/"+ new Guid() + "/";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(projectId);
            HttpClient.PostAsJsonAsync("api/Project", project).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectRequest.CreateProject(project);
        };

        It sends_a_create_project_request = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/Project", project);
            result.ShouldEqual(new Guid().ToString());
        };
    }

    #endregion

    #region UpdateProject(string projectId, Project project) Tests

    public class when_I_call_UpdateProject : Context
    {
        static bool result;
        static string id;
        static Project project;

        Establish context = () =>
        {
            id = new Guid().ToString();
            project = new Project("test");
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpClient.PutAsJsonAsync("api/Project/" + id, project).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectRequest.UpdateProject(id, project);
        };

        It updates_project = () =>
        {
            HttpClient.Received().PutAsJsonAsync("api/Project/" + id, project);
            result.ShouldBeTrue();
        };
    }

    #endregion

    #region DeleteProject(string projectId) Tests

    public class when_I_call_DeleteProject : Context
    {
        static bool result;
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpClient.DeleteAsync("api/Project/" + id).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectRequest.DeleteProject(id);
        };

        It deletes_project = () =>
        {
            HttpClient.Received().DeleteAsync("api/Project/" + id);
            result.ShouldBeTrue();
        };
    }

    #endregion
}
