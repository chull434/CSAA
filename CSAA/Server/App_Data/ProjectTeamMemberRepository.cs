﻿using System;
using System.Collections.Generic;
using CSAA.Models;

namespace Server.App_Data
{
    public class ProjectTeamMemberRepository : Repository, IRepository<ProjectTeamMember>
    {
        public ProjectTeamMemberRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProjectTeamMember> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectTeamMember GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProjectTeamMember member)
        {
            context.ProjectTeamMembers.Add(member);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}