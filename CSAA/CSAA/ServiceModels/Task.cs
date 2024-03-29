﻿namespace CSAA.ServiceModels
{
    public class Task
    {
        public string Id { get; set; }
        public string UserStoryId { get; set; }
        public string UserIdAssignedTo { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public int EstimatedHours { get; set; }
        public int EstimatedHoursRemaining { get; set; }
        public int HoursWorked { get; set; }
        public bool Completed { get; set; }

        public bool InSprintTeam { get; set; }
        public bool IsDeveloperInSprintTeam { get; set; }

        public Task()
        {

        }

        public Task(string title, string description, string userStoryId)
        {
            Title = title;
            Description = description;
            UserStoryId = userStoryId;
        }
    }
}