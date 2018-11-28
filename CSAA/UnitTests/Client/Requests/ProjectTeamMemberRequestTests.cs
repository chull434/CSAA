using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Client.Requests;
using CSAA.Enums;
using CSAA.ServiceModels;
using Machine.Specifications;
using Newtonsoft.Json;
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

    #region GetProjectTeamMembers() Tests

    public class when_I_call_GetProjectTeamMembers : Context
    {
        static List<ProjectTeamMember> result;

        Establish context = () =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var projectTeamMembers = new List<ProjectTeamMember>
            {
                new ProjectTeamMember()
            };
            response.Content = new StringContent(JsonConvert.SerializeObject(projectTeamMembers));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/ProjectTeamMember").Returns(response);
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.GetProjectTeamMembers();
        };

        It return_projectTeamMembers = () =>
        {
            HttpClient.Received().GetAsync("api/ProjectTeamMember");
            result.Count.ShouldEqual(1);
        };
    }

    #endregion

    #region SearchProjectTeamMembers(string projectId, User user)

    public class when_I_call_SearchProjectTeamMembers : Context
    {
        static List<User> result;
        static string projectId;
        static User user;

        Establish context = () =>
        {
            projectId = new Guid().ToString();
            user = new User();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var users = new List<User>
            {
                new User()
            };
            response.Content = new StringContent(JsonConvert.SerializeObject(users));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.PostAsJsonAsync("api/ProjectTeamMember/Search?id=" + projectId, user).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.SearchProjectTeamMembers(projectId, user);
        };

        It returns_users = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/ProjectTeamMember/Search?id=" + projectId, user);
            result.Count.ShouldEqual(1);
        };
    }

    #endregion

    #region GetProjectTeamMember(string projectTeamMemberId) Tests

    public class when_I_call_GetProjectTeamMember : Context
    {
        static ProjectTeamMember result;
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(new ProjectTeamMember()));
            response.Content.Headers.ContentType.MediaType = "application/json";
            HttpClient.GetAsync("api/ProjectTeamMember/" + id).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.GetProjectTeamMember(id);
        };

        It returns_projectTeamMember = () =>
        {
            HttpClient.Received().GetAsync("api/ProjectTeamMember/" + id);
            result.ShouldNotBeNull();
        };
    }

    #endregion

    #region AddProjectTeamMember(string email, string projectId)

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
            result = ProjectTeamMemberRequest.AddProjectTeamMember(email, projectId, Role.TeamMember);
        };

        It sends_a_add_team_member_request = () =>
        {
            HttpClient.Received().PostAsJsonAsync("api/ProjectTeamMember", Arg.Any<ProjectTeamMember>());
            result.ShouldBeTrue();
        };
    }

    #endregion

    #region UpdateProjectTeamMember(string projectTeamMemberId, ProjectTeamMember projectTeamMember)

    public class when_I_call_UpdateProjectTeamMember : Context
    {
        static bool result;
        static string id;
        static ProjectTeamMember projectTeamMember;

        Establish context = () =>
        {
            id = new Guid().ToString();
            projectTeamMember = new ProjectTeamMember();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpClient.PutAsJsonAsync("api/ProjectTeamMember/" + id, projectTeamMember).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.UpdateProjectTeamMember(id, projectTeamMember);
        };

        It send_a_update_request = () =>
        {
            HttpClient.Received().PutAsJsonAsync("api/ProjectTeamMember/" + id, projectTeamMember);
            result.ShouldBeTrue();
        };
    }

    #endregion

    #region DeleteProjectTeamMember(string projectTeamMemberId) Tests

    public class when_I_call_DeleteProjectTeamMember : Context
    {
        static bool result;
        static string id;

        Establish context = () =>
        {
            id = new Guid().ToString();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpClient.DeleteAsync("api/ProjectTeamMember/" + id).Returns(response);
        };

        Because of = () =>
        {
            result = ProjectTeamMemberRequest.DeleteProjectTeamMember(id);
        };

        It sends_a_delete_request = () =>
        {
            HttpClient.Received().DeleteAsync("api/ProjectTeamMember/" + id);
            result.ShouldBeTrue();
        };
    }

    #endregion
}
