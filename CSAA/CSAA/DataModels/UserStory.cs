using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSAA.DataModels
{
    public class UserStory
    {
        public Guid Id { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual Project Project { get; set; }

        public UserStory(string title, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
        }

        public ServiceModels.UserStory Map()
        {
            return new ServiceModels.UserStory()
            {              
                Id = Id.ToString(),
                ProjectId = ProjectId.ToString(),
                Title = Title,
                Description = Description
            };
        }
    }
}
