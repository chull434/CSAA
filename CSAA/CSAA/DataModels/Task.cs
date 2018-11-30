using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CSAA.Enums;

namespace CSAA.DataModels
{
    public class Task
    {
        public Guid Id { get; set; }

        [ForeignKey("UserStory")]
        public Guid UserStoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserIdAssignedTo { get; set; }

        public int EstimatedHours { get; set; }

        public int EstimatedHoursRemaining { get; set; }

        public int HoursWorked { get; set; }

        public bool Completed { get; set; }

        public virtual UserStory UserStory { get; set; }

        public Task()
        {
            Id = Guid.NewGuid();
        }

        public Task(string title, string description)
        {
            Id = Guid.NewGuid();           
            Title = title;
            Description = description;
        }

        public ServiceModels.Task Map()
        {
            return new ServiceModels.Task(Title, Description, UserStoryId.ToString())
            {
                Id = Id.ToString(),
                Completed = Completed,
                EstimatedHours = EstimatedHours,
                EstimatedHoursRemaining = EstimatedHoursRemaining,
                HoursWorked = HoursWorked,
                UserIdAssignedTo = UserIdAssignedTo,
            };
        }
    }
}
