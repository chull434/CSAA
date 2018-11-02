using System;
using Client.Requests;
using CSAA.ServiceModels;
using Machine.Specifications;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;

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
    public class when_i_get_project : Context
    {
        static List<Project> result;

        Establish context = () => { };

        Because of = () =>
        {
           result = ProjectRequest.GetProjects();
        };

        It creates_a_accountRequest = () =>
        {
            result.ShouldNotBeNull();
        };
    }



    #endregion

    #region GetProjectById(string projectId)



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



    #endregion

    #region DeleteProject(string projectId) Tests



    #endregion
}
