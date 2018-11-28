
using System.Windows.Input;
using System.Collections.Generic;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using UserStory = CSAA.ServiceModels.UserStory;

namespace Client.ViewModels
{
    class UserStoryViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IUserStoryRequest UserStoryRequest; 
        readonly IProjectRequest ProjectRequest;
        readonly IHttpClient HttpClient;       

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _back;
        public ICommand Back => _back;

        private readonly DelegateCommand _deleteUserStory;
        public ICommand DeleteUserStory => _deleteUserStory;

        private readonly DelegateCommand _saveUserStory;
        public ICommand SaveUserStory => _saveUserStory;

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

        int _userStoryPoints;
        public int UserStoryPoints
        {
            get => _userStoryPoints;
            set => SetProperty(ref _userStoryPoints, value);
        }

        public bool IsScrumMaster { get; set; }
        public bool IsProductOwner { get; set; }

        bool _canEdit;
        public bool CanEdit
        {
            get => _canEdit;
            set => SetProperty(ref _canEdit, value);
        }

        public UserStoryViewModel()
        {
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
        }

        public UserStoryViewModel(IHttpClient httpClient, string userStoryId, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            UserStoryRequest = new UserStoryRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            GetProject(projectId);
            this.projectId = projectId;
            GetUserStory(userStoryId);

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _saveUserStory = new DelegateCommand(OnSaveUserStory);
            _deleteUserStory = new DelegateCommand(OnDeleteUserStory);
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProject(projectId);           
            IsProductOwner = project.IsProductOwner;
            IsScrumMaster = project.IsScrumMaster;
            CanEdit = (IsProductOwner || IsScrumMaster);
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
        }

        private void OnLogout(object commandParameter)
        {
            AccountRequest.Logout();
            var login = new Login(HttpClient);
            var currentWindow = App.Current.MainWindow;
            App.Current.MainWindow = login;
            currentWindow.Close();
            login.Show();
        }

        private void OnHome(object commandParameter)
        {
            var home = new Home(HttpClient);
            var userStory = App.Current.MainWindow;
            App.Current.MainWindow = home;
            userStory.Close();
            home.Show();
        }

        private void OnBack(object commandParameter)
        {
            var back = new ProductBacklog(HttpClient, projectId);
            var userStory = App.Current.MainWindow;
            App.Current.MainWindow = back;
            userStory.Close();
            back.Show();
        }

        private void GetUserStory(string userStoryId)
        {
            this.userStoryId = userStoryId;
            var userStory = UserStoryRequest.GetUserStoryById(userStoryId);
            UserStoryTitle = userStory.Title;
            UserStoryDescription = userStory.Description;
            UserStoryPoints = userStory.StoryPoints;
        }

        private void OnSaveUserStory(object commandParameter)
        {
            UserStoryRequest.UpdateUserStory(userStoryId, new UserStory(UserStoryTitle, UserStoryDescription, projectId) {StoryPoints = UserStoryPoints});
            GetUserStory(userStoryId);
        }

        private void OnDeleteUserStory(object commandParameter)
        {
            UserStoryRequest.DeleteUserStory(userStoryId);
            _back.Execute(_back);
        }
    }
}
