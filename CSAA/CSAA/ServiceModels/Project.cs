using System.Collections.Generic;

namespace CSAA.ServiceModels
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Completion { get; set; }
        public List<ProjectTeamMember> ProjectTeam { get; set; }

        public Project()
        {
            ProjectTeam = new List<ProjectTeamMember>();
        }

        public Project(string Title)
        {
            this.Title = Title;
            ProjectTeam = new List<ProjectTeamMember>();
        }
    }
}