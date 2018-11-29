using System;
using System.Collections.Generic;
using System.Text;

namespace CSAA.ServiceModels
{
    public class Sprint
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<SprintTeamMember> SprintTeam { get; set; }
        public List<UserStory> SprintUserStories { get; set; }
        public List<UserStory> ProjectUserStories { get; set; }

        public bool IsScrumMaster { get; set; }

        public Sprint()
        {
            SprintTeam = new List<SprintTeamMember>();
            SprintUserStories = new List<UserStory>();
            ProjectUserStories = new List<UserStory>();
        }

        public Sprint(string Tile, string ProjectId, DateTime StartDate, DateTime EndDate)
        {
            this.Title = Tile;
            this.ProjectId = ProjectId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            SprintTeam = new List<SprintTeamMember>();
            SprintUserStories = new List<UserStory>();
            ProjectUserStories = new List<UserStory>();
        }
    }
}
