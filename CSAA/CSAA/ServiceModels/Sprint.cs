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

        public bool IsScrumMaster { get; set; }

        public Sprint()
        {
            
        }

        public Sprint(string Tile, string ProjectId, DateTime StartDate, DateTime EndDate)
        {
            this.Title = Tile;
            this.ProjectId = ProjectId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
    }
}
