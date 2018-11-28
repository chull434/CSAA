using Client.Requests;
using System.Collections.Generic;
using CSAA.ServiceModels;
using UserStory = CSAA.ServiceModels.UserStory;
using Client.Views;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class ProductBacklogViewModel : ViewModel
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

        public bool IsProductOwner { get; set; }

        public ProductBacklogViewModel(IHttpClient httpClient, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            UserStoryRequest = new UserStoryRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            GetProject(projectId);

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _newUserStory = new DelegateCommand(OnNewUserStory);
        }

        public ProductBacklogViewModel(IHttpClient httpClient, IAccountRequest accountRequest, IUserStoryRequest userStoryRequest, IProjectRequest projectRequest, string id)
        {
            HttpClient = httpClient;
            AccountRequest = accountRequest;
            UserStoryRequest = userStoryRequest;
            ProjectRequest = projectRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _newUserStory = new DelegateCommand(OnNewUserStory);
            projectId = id;
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
            ChangeView(new Views.Project(HttpClient, projectId));
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProject(projectId);
            UserStoryList = project.ProjectUserStories;
            ProjectTitle = project.Title;
            IsProductOwner = project.IsProductOwner;
        }

        private void OnOpenUserStory(string userStoryId)
        {
            ChangeView(new Views.UserStory(HttpClient, userStoryId, projectId));
        }

        private void OnNewUserStory(object commandParameter)
        {
            var userStoryId = UserStoryRequest.CreateUserStory(new UserStory("New User Story", "Description goes here...", projectId));
            ChangeView(new Views.UserStory(HttpClient, userStoryId, projectId));
        }
    }
}
