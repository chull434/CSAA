using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Project = CSAA.ServiceModels.Project;
using Task = CSAA.ServiceModels.Task;

namespace Client.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IProjectTeamMemberRequest ProjectTeamMemberRequest;
        readonly IHttpClient HttpClient;

        List<Project> _projectList = new List<Project>();
        public List<Project> ProjectList
        {
            get => _projectList;
            set => SetProperty(ref _projectList, value);
        }

        Project _selectedProject = new Project();
        public Project SelectedProject
        {
            set
            {
                OnOpenProject(value.Id);
            }
        }

        List<Task> _assignedTasks = new List<Task>();
        public List<Task> AssignedTasks
        {
            get => _assignedTasks;
            set => SetProperty(ref _assignedTasks, value);
        }

        List<ProjectTeamMember> _memberList = new List<ProjectTeamMember>();
        public List<ProjectTeamMember> MemberList
        {
            get => _memberList;
            set => SetProperty(ref _memberList, value);
        }

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _editProfile;
        public ICommand EditProfile => _editProfile;

        private readonly DelegateCommand _createProject;
        public ICommand CreateProject => _createProject;

        public HomeViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            ProjectTeamMemberRequest = new ProjectTeamMemberRequest(httpClient);
            _logout = new DelegateCommand(OnLogout);
            _editProfile = new DelegateCommand(OnEditProfile);
            _createProject = new DelegateCommand(OnCreateProject);
            GetProjects();
            GetTasks();
            GetTeamMembers();
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

        private void OnEditProfile(object commandParameter)
        {
            var profile = new Profile(HttpClient);
            var home = App.Current.MainWindow;
            App.Current.MainWindow = profile;
            home.Close();
            profile.Show();
        }

        private void OnCreateProject(object commandParameter)
        {
            var projectId = ProjectRequest.CreateProject(new Project("New Project"));
            var projectWindow = new Views.Project(HttpClient, projectId);
            var currentWindow = App.Current.MainWindow;
            App.Current.MainWindow = projectWindow;
            currentWindow.Close();
            projectWindow.Show();
        }

        private void OnOpenProject(string projectId)
        {
            var projectWindow = new Views.Project(HttpClient, projectId);
            var currentWindow = App.Current.MainWindow;
            App.Current.MainWindow = projectWindow;
            currentWindow.Close();
            projectWindow.Show();
        }

        private void GetProjects()
        {
            ProjectList = ProjectRequest.GetProjects();
        }

        private void GetTeamMembers()
        {
            MemberList = ProjectTeamMemberRequest.GetAllProjectTeamMembers();
        }

        private void GetTasks()
        {
            AssignedTasks.Add(new Task { Title = "Task 1", Project = "Project A" });
            AssignedTasks.Add(new Task { Title = "Task 2", Project = "Project A" });
            AssignedTasks.Add(new Task { Title = "Task 3", Project = "Project A" });
        }
    }
}
