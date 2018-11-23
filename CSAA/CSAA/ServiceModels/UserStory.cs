namespace CSAA.ServiceModels
{
    public class UserStory
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryPoints { get; set; }

        public UserStory()
        {

        }

        public UserStory(string title, string description, string projectId)
        {
            Title = title;
            Description = description;
            ProjectId = projectId;
            StoryPoints = 0;
        }
    }
}
