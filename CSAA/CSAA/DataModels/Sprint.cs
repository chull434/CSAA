using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CSAA.DataModels
{
    public class Sprint
    {
        public Guid Id { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<SprintTeamMember> SprintTeam { get; set; }
        public virtual List<UserStory> SprintUserStories { get; set; }

        public Sprint()
        {
            Id = Guid.NewGuid();
        }

        public Sprint(string Tile, Project Project, DateTime StartDate, DateTime EndDate)
        {
            Id = Guid.NewGuid();
            this.Title = Tile;
            this.Project = Project;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            SprintTeam = new List<SprintTeamMember>();
            SprintUserStories = new List<UserStory>();
        }

        public ServiceModels.Sprint Map()
        {
            return new ServiceModels.Sprint
            {
                Id = Id.ToString(),
                Title = Title,
                StartDate = StartDate,
                EndDate = EndDate,
                SprintTeam = SprintTeam.Select(m => m.Map()).ToList(),
                SprintUserStories = SprintUserStories.Select(m => m.Map()).ToList(),
                ProjectUserStories = Project.ProjectUserStories.Where(p => SprintUserStories.FirstOrDefault(s => s.Id.ToString() == p.Id.ToString()) == null).Select(m => m.Map()).ToList()
            };
        }
    }
}
