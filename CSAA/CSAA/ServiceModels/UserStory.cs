using System.Collections.Generic;

namespace CSAA.ServiceModels
{
    public class UserStory
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string SprintId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryPoints { get; set; }
        public int MarketValue { get; set; }
        public int Priority { get; set; }
        public string SprintTitle { get; set; }
        public List<AcceptanceTest> UserStoryAcceptanceTests { get; set; }
        public List<Task> UserStoryTasks { get; set; }

        public bool InSprintTeam { get; set; }

        public UserStory()
        {
            UserStoryAcceptanceTests = new List<AcceptanceTest>();
        }

        public UserStory(string title, string description, string projectId)
        {
            Title = title;
            Description = description;
            ProjectId = projectId;
            UserStoryAcceptanceTests = new List<AcceptanceTest>();
            UserStoryTasks = new List<Task>();
        }
    }
}
