﻿using CSAA.Models;
using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.Services
{
    public class ProjectService
    {
        private ProjectRepository repository;

        public ProjectService(ProjectRepository repository)
        {
            this.repository = repository;
        }

        public void CreateProject(Project project, string userId)
        {
            var member = new ProjectTeamMember(userId, project, Role.ProjectManager);
            project.ProjectTeam.Add(member);
            repository.Insert(project);
            repository.Save();
        }
    }
}