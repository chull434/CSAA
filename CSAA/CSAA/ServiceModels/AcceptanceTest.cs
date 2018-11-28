using System;
using System.Collections.Generic;
using System.Text;

namespace CSAA.ServiceModels
{
    public class AcceptanceTest
    {
        public string Id { get; set; }
        public string UserStoryId { get; set; }
        public string Title { get; set; }
        public string Criteria { get; set; }
        public bool Completed { get; set; }

        public AcceptanceTest()
        {

        }

        public AcceptanceTest(string title, string criteria, string userStoryId)
        {
            Title = title;
            Criteria = criteria;
            UserStoryId = userStoryId;
            Completed = false;
        }
    }
}
