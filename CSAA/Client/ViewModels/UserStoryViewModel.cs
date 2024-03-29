﻿
using System.Windows.Input;
using System.Collections.Generic;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using Task = CSAA.ServiceModels.Task;
using UserStory = CSAA.ServiceModels.UserStory;

namespace Client.ViewModels
{
    class UserStoryViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IUserStoryRequest UserStoryRequest; 
        readonly IProjectRequest ProjectRequest;
        readonly IAcceptanceTestRequest AcceptanceTestRequest;
        readonly ITaskRequest TaskRequest;

        readonly IHttpClient HttpClient;       

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _back;
        public ICommand Back => _back;

        private readonly DelegateCommand _deleteUserStory;
        public ICommand DeleteUserStory => _deleteUserStory;
        
        private readonly DelegateCommand _deleteAcceptanceTest;
        public ICommand DeleteAcceptanceTest => _deleteAcceptanceTest;

        private readonly DelegateCommand _saveUserStory;
        public ICommand SaveUserStory => _saveUserStory;

        private readonly DelegateCommand _addAcceptanceTest;
        public ICommand AddAcceptanceTest => _addAcceptanceTest;

        private readonly DelegateCommand _addTask;
        public ICommand AddTask => _addTask;

        string projectId;
        string userStoryId;

        string _userStoryTitle;
        public string UserStoryTitle
        {
            get => _userStoryTitle;
            set => SetProperty(ref _userStoryTitle, value);
        }

        string _userStoryDescription;
        public string UserStoryDescription
        {
            get => _userStoryDescription;
            set => SetProperty(ref _userStoryDescription, value);
        }

        string _sprintTitle;
        public string SprintTitle
        {
            get => _sprintTitle;
            set => SetProperty(ref _sprintTitle, value);
        }

        int _userStoryPoints;
        public int UserStoryPoints
        {
            get => _userStoryPoints;
            set => SetProperty(ref _userStoryPoints, value);
        }

        int _userStoryPriority;
        public int UserStoryPriority
        {
            get => _userStoryPriority;
            set => SetProperty(ref _userStoryPriority, value);
        }

        int _userStoryMarketValue;
        public int UserStoryMarketValue
        {
            get => _userStoryMarketValue;
            set => SetProperty(ref _userStoryMarketValue, value);
        }

        public bool IsScrumMaster { get; set; }
        public bool IsProductOwner { get; set; }
        public bool CanSave { get; set; }
        public bool InSprintTeam { get; set; }

        private string _selectedAcceptanceTestId { get; set; }
        public AcceptanceTest SelectedAcceptanceTest
        {
            set
            {
                if (value != null)
                { 
                    _selectedAcceptanceTestId = value.Id;
                }
            }
        }

        List<AcceptanceTest> _AcceptanceTestList = new List<AcceptanceTest>();
        public List<AcceptanceTest> AcceptanceTestList
        {
            get => _AcceptanceTestList;
            set
            {
                value.ForEach(m => m.OnValueChange = OnAcceptanceTestChange);
                SetProperty(ref _AcceptanceTestList, value);
            }
        }

        List<Task> _taskList = new List<Task>();
        public List<Task> TaskList
        {
            get => _taskList;
            set => SetProperty(ref _taskList, value);
        }

        Task _selectedTask = new Task();
        public Task SelectedTask
        {
            set => OnSelectTask(value.Id);
        }

        public UserStoryViewModel(IHttpClient httpClient, string userStoryId, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            UserStoryRequest = new UserStoryRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            AcceptanceTestRequest = new AcceptanceTestRequest(httpClient);
            TaskRequest = new TaskRequest(httpClient);
            GetProject(projectId);
            GetUserStory(userStoryId);

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _saveUserStory = new DelegateCommand(OnSaveUserStory);
            _deleteUserStory = new DelegateCommand(OnDeleteUserStory);
            _deleteAcceptanceTest = new DelegateCommand(OnDeleteAcceptanceTest);
            _addAcceptanceTest = new DelegateCommand(OnAddAcceptanceTest);
            _addTask = new DelegateCommand(OnAddTask);
        }

        public UserStoryViewModel(IAccountRequest accountRequest, IUserStoryRequest userStoryRequest, IProjectRequest projectRequest, string userStoryId, string projectId)
        {
            AccountRequest = accountRequest;
            ProjectRequest = projectRequest;
            UserStoryRequest = userStoryRequest;
            this.projectId = projectId;
            this.userStoryId = userStoryId;

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _saveUserStory = new DelegateCommand(OnSaveUserStory);
            _deleteUserStory = new DelegateCommand(OnDeleteUserStory);
            _deleteAcceptanceTest = new DelegateCommand(OnDeleteAcceptanceTest);
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
            ChangeView(new ProductBacklog(HttpClient, projectId));
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProject(projectId);
            IsProductOwner = project.IsProductOwner;
            IsScrumMaster = project.IsScrumMaster;
            CanSave = IsProductOwner || IsScrumMaster;
            InSprintTeam = false;
        }

        private void GetUserStory(string userStoryId)
        {
            this.userStoryId = userStoryId;
            var userStory = UserStoryRequest.GetUserStoryById(userStoryId);
            UserStoryTitle = userStory.Title;
            UserStoryDescription = userStory.Description;
            SprintTitle = userStory.SprintTitle;
            UserStoryPoints = userStory.StoryPoints;
            UserStoryPriority = userStory.Priority;
            UserStoryMarketValue = userStory.MarketValue;
            AcceptanceTestList = userStory.UserStoryAcceptanceTests;
            TaskList = userStory.UserStoryTasks;
            if (userStory.SprintId != null)
            {
                IsProductOwner = false;
                IsScrumMaster = false;
                CanSave = false;
                InSprintTeam = userStory.InSprintTeam;
            }
        }

        private void OnSaveUserStory(object commandParameter)
        {
            UserStoryRequest.UpdateUserStory(userStoryId, new UserStory(UserStoryTitle, UserStoryDescription, projectId) { StoryPoints = UserStoryPoints, Priority = UserStoryPriority, MarketValue = UserStoryMarketValue});
            GetUserStory(userStoryId);
        }

        private void OnDeleteUserStory(object commandParameter)
        {
            UserStoryRequest.DeleteUserStory(userStoryId);
            _back.Execute(_back);
        }

        private void OnAddAcceptanceTest(object commandParameter)
        {
            AcceptanceTestRequest.CreateAcceptanceTest(new AcceptanceTest("Accecptance Test Title", "Description goes here...", userStoryId));
            GetUserStory(userStoryId);
        } 

        private void OnAddTask(object commandParameter)
        {
           var taskId = TaskRequest.CreateTask(new Task("Task Title", "Description goes here...", userStoryId));
           ChangeView(new Views.Task(HttpClient, taskId, userStoryId, projectId));
        } 

        public void OnAcceptanceTestChange(AcceptanceTest acceptanceTest)
        {
            acceptanceTest.OnValueChange = null;

            AcceptanceTestRequest.UpdateAcceptanceTest(acceptanceTest.Id, acceptanceTest);
            GetProject(projectId);
            GetUserStory(userStoryId);

            acceptanceTest.OnValueChange = OnAcceptanceTestChange;
        }

        private void OnDeleteAcceptanceTest(object commandParameter)
        {
            AcceptanceTestRequest.DeleteAcceptanceTest(_selectedAcceptanceTestId);
            GetUserStory(userStoryId);
        }

        private void OnSelectTask(string taskId)
        {
            ChangeView(new Views.Task(HttpClient, taskId, userStoryId, projectId));
        }
    }
}
