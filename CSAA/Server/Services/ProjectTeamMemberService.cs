using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.DataModels;
using CSAA.Enums;
using Server.App_Data;

namespace Server.Services
{
    public class ProjectTeamMemberService : IProjectTeamMemberService
    {
        private IRepository<ProjectTeamMember> repository;
        private IProjectService projectService;

        public ProjectTeamMemberService(IRepository<ProjectTeamMember> repository, IProjectService projectService)
        {
            this.repository = repository;
            this.projectService = projectService;
        }

        public void AddTeamMember(string userId, string projectId)
        {
            var project = projectService.GetProject(projectId);
            var teamMember = new ProjectTeamMember(userId, project, Role.TeamMember);
            project.ProjectTeam.Add(teamMember);
            repository.Save();
        }
    }
}