﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public int StoryPoints { get; set; }

        public virtual Project Project { get; set; }

        public virtual List<AcceptanceTest> UserStoryAcceptanceTests { get; set; }

        public UserStory()
        {
            Id = Guid.NewGuid();
        }

        public UserStory(string title, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            StoryPoints = 0;
            UserStoryAcceptanceTests = new List<AcceptanceTest>();
        }

        public ServiceModels.UserStory Map()
        {
            return new ServiceModels.UserStory(Title, Description, ProjectId.ToString())
            {
                UserStoryAcceptanceTests = UserStoryAcceptanceTests.Select(m => m.Map()).ToList(),
                Id = Id.ToString(),
                StoryPoints = StoryPoints,
            };
        }
    }
}
