namespace CSAA.ServiceModels
{
    public class UserStory
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public UserStory()
        {

        }

        public UserStory(string title, string description)
        {
            Id = Id;
            Title = title;
            Description = description;
        }
    }
}
