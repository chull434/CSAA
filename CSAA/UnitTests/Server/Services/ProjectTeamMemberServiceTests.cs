using System;
using System.Linq;
using CSAA.DataModels;
using Machine.Specifications;
using NSubstitute;
using Server.App_Data;
using Server.Services;

namespace UnitTests.Server.Services.ProjectTeamMemberServiceTests
{
    public class Context
    {
        public static IRepository<ProjectTeamMember> Repository;
        public static IRepository<Project> ProjectRepository;
        public static ProjectTeamMemberService Service;

        Establish context = () =>
        {
            Repository = Substitute.For<IRepository<ProjectTeamMember>>();
            ProjectRepository = Substitute.For<IRepository<Project>>();
            Service = new ProjectTeamMemberService(Repository, ProjectRepository);
        };
    }

    #region Constructor Tests

    public class when_I_Construct_ProjectService : Context
    {
        static ProjectTeamMemberService projectTeamMemberService;

        Because of = () =>
        {
            projectTeamMemberService = new ProjectTeamMemberService(Repository, ProjectRepository);
        };

        It constructs_project_team_member_service = () =>
        {
            projectTeamMemberService.ShouldNotBeNull();
        };
    }

    #endregion

    #region AddTeamMember() Tests

    public class when_I_call_AddTeamMember : Context
    {
        static string userId;
        static string projectId;
        static Project project;

        Establish context = () =>
        {
            projectId = Guid.NewGuid().ToString();
            userId = Guid.NewGuid().ToString();
            project = new Project("My Title");
            ProjectRepository.GetByID(projectId).Returns(project);
        };

        Because of = () =>
        {
            Service.AddProjectTeamMember(userId, projectId);
        };

        It adds_team_member_to_team = () =>
        {
            project.ProjectTeam.FirstOrDefault(m => m.UserId == userId).ShouldNotBeNull();
            Repository.Received().Save();
        };
    }

    #endregion
}
