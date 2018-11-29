namespace CSAA.ServiceModels
{
    public class Task
    {
        public string Id { get; set; }
        public string UserStoryId { get; set; }

        public delegate void OnChange(Task task);
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

        private string _userIdAssignedTo;
        public string UserIdAssignedTo
        {
            get => _userIdAssignedTo;
            set
            {
                _userIdAssignedTo = value;
                OnValueChange?.Invoke(this);
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnValueChange?.Invoke(this);
            }
        }

        private int _estimatedHours;
        public int EstimatedHours
        {
            get => _estimatedHours;
            set
            {
                _estimatedHours = value;
                OnValueChange?.Invoke(this);
            }
        }

        private int _estimatedHoursRemaining;
        public int EstimatedHoursRemaining
        {
            get => _estimatedHoursRemaining;
            set
            {
                _estimatedHoursRemaining = value;
                OnValueChange?.Invoke(this);
            }
        }

        private int _hoursWorked;
        public int HoursWorked
        {
            get => _hoursWorked;
            set
            {
                _hoursWorked = value;
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

        public Task()
        {

        }

        public Task(string title, string description, string userStoryId)
        {
            Title = title;
            Description = description;
            UserStoryId = userStoryId;
            UserIdAssignedTo = "";
            HoursWorked = 0;
            EstimatedHours = 0;
            EstimatedHoursRemaining = 0;
            Completed = false;
        }
    }
}