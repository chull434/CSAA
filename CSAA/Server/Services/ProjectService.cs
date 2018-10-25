﻿using CSAA.Models;
using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Services
{
    public class ProjectService
    {
        private ProjectRepository repository;

        public ProjectService(ProjectRepository repository)
        {
            this.repository = repository;
        }

        public void CreateProject(Project project)
        {
            repository.Insert(project);
            repository.Save();
        }
    }
}