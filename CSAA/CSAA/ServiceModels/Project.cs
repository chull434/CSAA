using System.Collections.Generic;

namespace CSAA.ServiceModels
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Completion { get; set; }
        public List<ProjectTeamMember> ProjectTeam { get; set; }
        public List<UserStory> ProjectUserStories { get; set; }

        public bool IsProjectManager { get; set; }
        public bool IsProductOwner { get; set; }
        public bool IsScrumMaster { get; set; }

        public Project()
        {
            ProjectTeam = new List<ProjectTeamMember>();
            ProjectUserStories = new List<UserStory>();
        }

        public Project(string Title)
        {
            this.Title = Title;
            ProjectTeam = new List<ProjectTeamMember>();
            ProjectUserStories = new List<UserStory>();
        }
    }
}