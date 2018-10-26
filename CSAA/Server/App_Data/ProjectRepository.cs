﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.Models;

namespace Server.App_Data
{
    public class ProjectRepository : IRepository<Project>
    {
        ServerDbContext context;

        public ProjectRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Project project)
        {
            context.Projects.Add(project);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}