using System;
using System.Collections.Generic;
using System.Text;

namespace CSAA.ServiceModels
{
    public class AcceptanceTest
    {
        public string Id { get; set; }
        public string UserStoryId { get; set; }

        public delegate void OnChange(AcceptanceTest acceptanceTest);
        public OnChange OnValueChange;

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnValueChange?.Invoke(this);
            }
        }

        private string _criteria;
        public string Criteria
        {
            get => _criteria;
            set
            {
                _criteria = value;
                OnValueChange?.Invoke(this);
            }
        }

        private bool _completed;
        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                OnValueChange?.Invoke(this);
            }
        }

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
