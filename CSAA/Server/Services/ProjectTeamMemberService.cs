using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.Models;
using Server.App_Data;

namespace Server.Services
{
    public class ProjectTeamMemberService : IProjectTeamMemberService
    {
        private IProjectService ProjectService;
        private IRepository<ProjectTeamMember> repository;

        public void AddTeamMember(string email, string projectId)
        {
            var userId = repository.GetUserIdFromEmail(email);
            var project = ProjectService.GetProject(projectId);
            var teamMember = new ProjectTeamMember(userId, project, Role.TeamMember);
        }
    }
}