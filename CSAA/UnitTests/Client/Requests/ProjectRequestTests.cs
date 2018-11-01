using System.Net;
using System.Net.Http;
using Client.Requests;
using Machine.Specifications;
using NSubstitute;
using System;
using CSAA.DataModels;

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

    #region Create Project Tests

    public class when_I_call_CreateProject : Context
    {
        static bool result;
        static Project project;

        Establish context = () =>
        {
            project = new Project("MyTitle");
            HttpClient.PostAsJsonAsync("api/Project", project).Returns(new HttpResponseMessage(HttpStatusCode.OK));
        };

        Because of = () =>
        {
            result = ProjectRequest.CreateProject(project);
        };

        It sends_a_create_project_request = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/Project", project);
            result.ShouldBeTrue();
        };
    }

    #endregion
}
