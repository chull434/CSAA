using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        }

        public ServiceModels.Sprint Map()
        {
            return new ServiceModels.Sprint
            {
                Id = Id.ToString(),
                Title = Title,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
