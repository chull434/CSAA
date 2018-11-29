using System;
using System.Collections.Generic;
using System.Linq;
using CSAA.Enums;

namespace CSAA.DataModels
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual List<ProjectTeamMember> ProjectTeam { get; set; }
        public virtual List<UserStory> ProjectUserStories { get; set; }
        public virtual List<Sprint> Sprints { get; set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Title = "My Project";
            ProjectTeam = new List<ProjectTeamMember>();
            ProjectUserStories = new List<UserStory>();
            Sprints = new List<Sprint>();
        }

        public Project(string Title)
        {
            Id = Guid.NewGuid();
            this.Title = Title;
            ProjectTeam = new List<ProjectTeamMember>();
            ProjectUserStories = new List<UserStory>();
            Sprints = new List<Sprint>();
        }

        public ServiceModels.Project Map()
        {
            return new ServiceModels.Project(Title)
            {
                ProjectUserStories = ProjectUserStories.Select(m => m.Map()).ToList(),
                ProjectTeam = ProjectTeam.Select(m => m.Map()).ToList(),
                Sprints = Sprints.Select(s => s.Map()).ToList(),
                Id = Id.ToString()
            };
        }

        public bool RoleAssigned(Role role)
        {
            foreach (var projectTeamMember in ProjectTeam)
            {
                if (projectTeamMember.HasRole(role)) return true;
            }

            return false;
        }
    }
}
