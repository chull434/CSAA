using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CSAA.Enums;

namespace CSAA.DataModels
{
    public class AcceptanceTest
    {
        public Guid Id { get; set; }

        [ForeignKey("UserStory")]
        public Guid UserStoryId { get; set; }

        public string Title { get; set; }

        public string Criteria { get; set; }

        public bool Completed { get; set; }

        public virtual UserStory UserStory { get; set; }

        public AcceptanceTest()
        {
            Id = Guid.NewGuid();
        }

        public AcceptanceTest(string title, string criteria, bool completed)
        {
            Id = Guid.NewGuid();
            Title = title;
            Criteria = criteria;
            Completed = completed;
        }

        public ServiceModels.AcceptanceTest Map()
        {
            return new ServiceModels.AcceptanceTest(Title, Criteria, UserStoryId.ToString())
            {
                Id = Id.ToString(),
                Completed = Completed,
            };
        }
    }
}
