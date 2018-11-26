using Client.Requests;
using System.Collections.Generic;
using CSAA.ServiceModels;
using UserStory = CSAA.ServiceModels.UserStory;
using Client.Views;
using System.Windows.Input;

namespace Client.ViewModels
{
    class ProductBacklogViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IUserStoryRequest UserStoryRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IHttpClient HttpClient;

        List<UserStory> _userStoryList = new List<UserStory>();
        public List<UserStory> UserStoryList
        {
            get => _userStoryList;
            set => SetProperty(ref _userStoryList, value);
        }

        UserStory _selectedUserStory = new UserStory();
        public UserStory SelectedUserStory
        {
            set
            {
                OnOpenUserStory(value.Id);
            }
        }

        string projectId;
        string _projectTitle;
        public string ProjectTitle
        {
            get => _projectTitle;
            set => SetProperty(ref _projectTitle, value);
        }

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _back;
        public ICommand Back => _back;

        private readonly DelegateCommand _newUserStory;
        public ICommand NewUserStory => _newUserStory;

        public ProductBacklogViewModel(IHttpClient httpClient, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            UserStoryRequest = new UserStoryRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            _logout = new DelegateCommand(OnLogout);
            _newUserStory = new DelegateCommand(OnNewUserStory);
            _home = new DelegateCommand(OnHome);
            _back = new DelegateCommand(OnBack);
            GetProject(projectId);
            GetUserStories();
        }

        private void OnLogout(object commandParameter)
        {
            AccountRequest.Logout();
            var login = new Login(HttpClient);
            var home = App.Current.MainWindow;
            App.Current.MainWindow = login;
            home.Close();
            login.Show();
        }

        private void OnHome(object commandParameter)
        {
            var home = new Home(HttpClient);
            var projecyBacklog = App.Current.MainWindow;
            App.Current.MainWindow = home;
            projecyBacklog.Close();
            home.Show();
        }

        private void OnBack(object commandParameter)
        {
            var back = new Views.Project(HttpClient, projectId);
            var projecyBacklog = App.Current.MainWindow;
            App.Current.MainWindow = back;
            projecyBacklog.Close();
            back.Show();
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProject(projectId);
            ProjectTitle = project.Title;
        }

        private void OnOpenUserStory(string userStoryId)
        {
            var userStoryWindow = new Views.UserStory(HttpClient, userStoryId, projectId);
            var currentWindow = App.Current.MainWindow;
            App.Current.MainWindow = userStoryWindow;
            currentWindow.Close();
            userStoryWindow.Show();
        }

        private void OnNewUserStory(object commandParameter)
        {
            var userStoryId = UserStoryRequest.CreateUserStory(new UserStory("New User Story", "Description goes here...", projectId));
            var userStoryWindow = new Views.UserStory(HttpClient, userStoryId, projectId);
            var currentWindow = App.Current.MainWindow;
            App.Current.MainWindow = userStoryWindow;
            currentWindow.Close();
            userStoryWindow.Show();
        }

        private void GetUserStories()
        {
            UserStoryList = UserStoryRequest.GetUserStories();
        }
    }
}
