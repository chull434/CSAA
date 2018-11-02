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

    #region GetAllProjectTeamMembersAsync() Tests



    #endregion

    #region GetProjectTeamMemberAsync(string projectTeamMemberId) Tests



    #endregion

    #region AddProjectTeamMemberAsync(string email, string projectId)

    public class when_I_call_AddTeamMember : Context
    {
        static string email;
        static string projectId;
        static bool result;

        Establish context = () =>
        {
            email = "testuser@localhost";
            projectId = new Guid().ToString();
            HttpClient.PostAsJsonAsync("api/ProjectTeamMember", Arg.Any<ProjectTeamMember>()).Returns(new HttpResponseMessage(HttpStatusCode.OK));
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.AddProjectTeamMember(email, projectId);
        };

        It sends_a_add_team_member_request = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/ProjectTeamMember", Arg.Any<ProjectTeamMember>());
            result.ShouldBeTrue();
        };
    }

    #endregion

    #region UpdateProjectTeamMemberAsync(string projectTeamMemberId, ProjectTeamMember projectTeamMember)



    #endregion

    #region DeleteProjectTeamMemberAsync(string projectTeamMemberId) Tests



    #endregion
}
