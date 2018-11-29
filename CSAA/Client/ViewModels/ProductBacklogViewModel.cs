using Client.Requests;
using System.Collections.Generic;
using CSAA.ServiceModels;
using UserStory = CSAA.ServiceModels.UserStory;
using Client.Views;
using System.Windows.Input;
using System.Linq;

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

        List<UserStory> _sortedUserStoryList = new List<UserStory>();
        public List<UserStory> SortedUserStoryList
        {
            get => _sortedUserStoryList;
            set => SetProperty(ref _sortedUserStoryList, value);
        }

        UserStory _selectedUserStory = new UserStory();
        public UserStory SelectedUserStory
        {
            get => _selectedUserStory;
            set
            {
                if (value != null)
                {
                    _selectedUserStory = value;
                }
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

        private readonly DelegateCommand _moveUp;
        public ICommand MoveUp => _moveUp;

        private readonly DelegateCommand _moveDown;
        public ICommand MoveDown => _moveDown;

        private readonly DelegateCommand _openUserStory;
        public ICommand OpenUserStory => _openUserStory;

        public bool IsProductOwner { get; set; }

        public ProductBacklogViewModel(IHttpClient httpClient, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            UserStoryRequest = new UserStoryRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            GetProject(projectId);
            _sortedUserStoryList = _userStoryList.OrderBy(o => o.Priority).ToList();
            UserStoryList = _sortedUserStoryList;

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _back = new DelegateCommand(OnBack);
            _newUserStory = new DelegateCommand(OnNewUserStory);
            _openUserStory = new DelegateCommand(OnOpenUserStory);
            _moveUp = new DelegateCommand(OnMoveUp);
            _moveDown = new DelegateCommand(OnMoveDown);
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
            _openUserStory = new DelegateCommand(OnOpenUserStory);
            _moveUp = new DelegateCommand(OnMoveUp);
            _moveDown = new DelegateCommand(OnMoveDown);
            projectId = id;
            _sortedUserStoryList = _userStoryList.OrderBy(o => o.Priority).ToList();
            UserStoryList = _sortedUserStoryList;
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

        private void OnOpenUserStory(object commandParameter)
        {
            ChangeView(new Views.UserStory(HttpClient, SelectedUserStory.Id, projectId));
        }

        private void OnNewUserStory(object commandParameter)
        {
            var userStoryId = UserStoryRequest.CreateUserStory(new UserStory("New User Story", "Description goes here...", projectId));
            ChangeView(new Views.UserStory(HttpClient, userStoryId, projectId));
        }

        private void OnMoveUp(object commandParameter)
        {
            if (SelectedUserStory.Id != null)
            {
                if (_selectedUserStory.Priority != 1)
                {

                    foreach (UserStory userStory in UserStoryList)
                    {
                        if (userStory.Priority == _selectedUserStory.Priority - 1)
                        {
                            userStory.Priority = _selectedUserStory.Priority;
                            UserStoryRequest.UpdateUserStory(userStory.Id, new UserStory(userStory.Title, userStory.Description, projectId) { Priority = userStory.Priority });
                            break;
                        }
                    }
                    _selectedUserStory.Priority--;
                }
                UserStoryRequest.UpdateUserStory(_selectedUserStory.Id, new UserStory(_selectedUserStory.Title, _selectedUserStory.Description, projectId) { Priority = _selectedUserStory.Priority });
                _sortedUserStoryList = _userStoryList.OrderBy(o => o.Priority).ToList();
                UserStoryList = _sortedUserStoryList;
            }
        }

        private void OnMoveDown(object commandParameter)
        {
            if (SelectedUserStory.Id != null)
            {
                if (_selectedUserStory.Priority != _userStoryList.Count())
                {
                    foreach (UserStory userStory in UserStoryList)
                    {
                        if (userStory.Priority == _selectedUserStory.Priority + 1)
                        {
                            userStory.Priority = _selectedUserStory.Priority;
                            UserStoryRequest.UpdateUserStory(userStory.Id, new UserStory(userStory.Title, userStory.Description, projectId) { Priority = userStory.Priority });
                            break;
                        }
                    }
                    _selectedUserStory.Priority++;
                }
                UserStoryRequest.UpdateUserStory(_selectedUserStory.Id, new UserStory(_selectedUserStory.Title, _selectedUserStory.Description, projectId) { Priority = _selectedUserStory.Priority });
                _sortedUserStoryList = _userStoryList.OrderBy(o => o.Priority).ToList();
                UserStoryList = _sortedUserStoryList;
            }
        }
    }
}
