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

        public HomeViewModel(IHttpClient httpClient, IAccountRequest accountRequest, IProjectRequest projectRequest, IProjectTeamMemberRequest projectTeamMemberRequest)
        {
            HttpClient = httpClient;
            AccountRequest = accountRequest;
            ProjectRequest = projectRequest;
            ProjectTeamMemberRequest = projectTeamMemberRequest;
            _logout = new DelegateCommand(OnLogout);
            _editProfile = new DelegateCommand(OnEditProfile);
            _createProject = new DelegateCommand(OnCreateProject);
        }

        private void OnLogout(object commandParameter)
        {
            AccountRequest.Logout();
            ChangeView(new Login(HttpClient));
        }

        private void OnEditProfile(object commandParameter)
        {
            ChangeView(new Profile(HttpClient));
        }

        private void OnCreateProject(object commandParameter)
        {
            var projectId = ProjectRequest.CreateProject(new Project("New Project"));
            ChangeView(new Views.Project(HttpClient, projectId));
        }

        private void OnOpenProject(string projectId)
        {
            ChangeView(new Views.Project(HttpClient, projectId));
        }

        private void GetProjects()
        {
            ProjectList = ProjectRequest.GetProjects();
        }

        private void GetTeamMembers()
        {
            MemberList = ProjectTeamMemberRequest.GetProjectTeamMembers();
        }

        private void GetTasks()
        {
            AssignedTasks.Add(new Task { Title = "Task 1", Project = "Project A" });
            AssignedTasks.Add(new Task { Title = "Task 2", Project = "Project A" });
            AssignedTasks.Add(new Task { Title = "Task 3", Project = "Project A" });
        }
    }
}
