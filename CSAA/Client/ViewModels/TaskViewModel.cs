using System.Windows.Input;
using System.Collections.Generic;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using Task = CSAA.ServiceModels.Task;

namespace Client.ViewModels
{
    class TaskViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly ITaskRequest TaskRequest;
        readonly IHttpClient HttpClient;

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _back;
        public ICommand Back => _back;

        private readonly DelegateCommand _deleteTask;
        public ICommand DeleteTask => _deleteTask;

        private readonly DelegateCommand _saveTask;
        public ICommand SaveTask => _saveTask;

        string projectId;
        string userStoryId;
        string taskId;

        public bool InSprintTeam { get; set; }

        string _taskTitle;
        public string TaskTitle
        {
            get => _taskTitle;
            set => SetProperty(ref _taskTitle, value);
        }

        string _taskDescription;
        public string TaskDescription
        {
            get => _taskDescription;
            set => SetProperty(ref _taskDescription, value);
        }

        int _taskEstimatedHours;
        public int TaskEstimatedHours
        {
            get => _taskEstimatedHours;
            set => SetProperty(ref _taskEstimatedHours, value);
        }

        int _taskEstimatedHoursRemaining;
        public int TaskEstimatedHoursRemaining
        {
            get => _taskEstimatedHoursRemaining;
            set => SetProperty(ref _taskEstimatedHoursRemaining, value);
        }

        int _taskHoursWorked;
        public int TaskHoursWorked
        {
            get => _taskHoursWorked;
            set => SetProperty(ref _taskHoursWorked, value);
        }

        bool _taskCompleted;
        public bool TaskCompleted
        {
            get => _taskCompleted;
            set => SetProperty(ref _taskCompleted, value);
        }

        public TaskViewModel(IHttpClient httpClient, string taskId, string userStoryId, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            TaskRequest = new TaskRequest(httpClient);
            GetTask(taskId);
            this.projectId = projectId;
            this.userStoryId = userStoryId;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _deleteTask = new DelegateCommand(OnDeleteTask);
            _saveTask = new DelegateCommand(OnSaveTask);
        }

        public TaskViewModel(IAccountRequest accountRequest, ITaskRequest taskRequest, string taskId, string userStoryId, string projectId)
        {
            AccountRequest = accountRequest;
            TaskRequest = taskRequest;
            this.projectId = projectId;
            this.userStoryId = userStoryId;
            this.taskId = taskId;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _deleteTask = new DelegateCommand(OnDeleteTask);
            _saveTask = new DelegateCommand(OnSaveTask);
        }

        private void GetTask(string taskId)
        {
            this.taskId = taskId;
            var task = TaskRequest.GetTaskById(taskId);
            TaskTitle = task.Title;
            TaskDescription = task.Description;
            TaskEstimatedHours = task.EstimatedHours;
            TaskEstimatedHoursRemaining = task.EstimatedHoursRemaining;
            TaskHoursWorked = task.HoursWorked;
            TaskCompleted = task.Completed;
            InSprintTeam = task.InSprintTeam;
        }

        private void OnLogout(object commandParameter)
        {
            AccountRequest.Logout();
            ChangeView(new Login(HttpClient));
        }

        private void OnHome(object commandParameter)
        {
            ChangeView(new Home(HttpClient));
        }

        private void OnBack(object commandParameter)
        {
            ChangeView(new Views.UserStory(HttpClient, userStoryId, projectId));
        }

        private void OnDeleteTask(object commandParameter)
        {
            TaskRequest.DeleteTask(taskId);
            ChangeView(new Views.UserStory(HttpClient, userStoryId, projectId));
        }

        private void OnSaveTask(object commandParameter)
        {
            var task = new Task
            {
                Title = TaskTitle,
                Description = TaskDescription,
                EstimatedHours = TaskEstimatedHours,
                EstimatedHoursRemaining = TaskEstimatedHoursRemaining,
                HoursWorked = TaskHoursWorked,
                Completed = TaskCompleted
            };
            TaskRequest.UpdateTask(taskId, task);
            GetTask(taskId);
        }
    }
}
