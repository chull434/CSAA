using System;
using System.Net;
using System.Net.Http;
using Client.Requests;
using CSAA.ServiceModels;
using Machine.Specifications;
using NSubstitute;


namespace UnitTests.Client.Requests.ProjectTeamMemberRequests
{
    public class Context
    {
        public static ProjectTeamMemberRequest ProjectTeamMemberRequest;
        public static IHttpClient HttpClient;

        Establish context = () =>
        {
            HttpClient = Substitute.For<IHttpClient>();
            ProjectTeamMemberRequest = new ProjectTeamMemberRequest(HttpClient);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_with_HttpClient : Context
    {
        static ProjectTeamMemberRequest projectTeamMemberRequest;

        Establish context = () => { };

        Because of = () =>
        {
            projectTeamMemberRequest = new ProjectTeamMemberRequest(HttpClient);
        };

        It creates_a_projectTeamMemberRequest = () =>
        {
            projectTeamMemberRequest.ShouldNotBeNull();
        };
    }

    #endregion

    #region Add Team Member Tests

    public class when_I_call_AddTeamMember : Context
    {
        static string email;
        static string projectId;
        static bool result;

        Establish context = () =>
        {
            email = "testuser@localhost";
            projectId = new Guid().ToString();
            HttpClient.PostAsJsonAsync("api/ProjectTeamMember", Arg.Any<AddTeamMember>()).Returns(new HttpResponseMessage(HttpStatusCode.OK));
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.AddTeamMember(email, projectId);
        };

        It sends_a_add_team_member_request = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/ProjectTeamMember", Arg.Any<AddTeamMember>());
            result.ShouldBeTrue();
        };
    }

    #endregion
}
