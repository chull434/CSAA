﻿using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.DataModels;
using CSAA.Enums;
using Server.Models;

namespace Server.Services
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> repository;

        public ProjectService(IRepository<Project> repository)
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

        public Project GetProject(string projectId)
        {
            return repository.GetByID(projectId);
        }
    }
}