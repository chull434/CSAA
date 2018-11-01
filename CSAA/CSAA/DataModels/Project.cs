﻿using System;
using System.Collections.Generic;

namespace CSAA.DataModels
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<ProjectTeamMember> ProjectTeam { get; set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Title = "My Title";
            ProjectTeam = new List<ProjectTeamMember>();
        }

        public Project(string Title)
        {
            Id = Guid.NewGuid();
            this.Title = Title;
            ProjectTeam = new List<ProjectTeamMember>();
        }
    }
}
