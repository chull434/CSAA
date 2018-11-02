using System.Windows.Input;
using System.Collections.Generic;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using Project = CSAA.ServiceModels.Project;

namespace Client.ViewModels
{
    public class ProjectViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IProjectTeamMemberRequest ProjectTeamMemberRequest;
        readonly IHttpClient HttpClient;

        string projectId;

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _saveProject;
        public ICommand SaveProject => _saveProject;

        private readonly DelegateCommand _addTeamMember;
        public ICommand AddTeamMember => _addTeamMember;


        string _projectTitle;
        public string ProjectTitle
        {
            get => _projectTitle;
            set => SetProperty(ref _projectTitle, value);
        }

        string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        List<ProjectTeamMember> _memberList = new List<ProjectTeamMember>();
        public List<ProjectTeamMember> MemberList
        {
            get => _memberList;
            set
            {
                value.ForEach(m => m.OnRoleChange = OnProjectTeamMemberRoleChange);
                SetProperty(ref _memberList, value);
            }
        }

        public void OnProjectTeamMemberRoleChange(ProjectTeamMember projectTeamMember)
        {
            projectTeamMember.OnRoleChange = null;
            ProjectTeamMemberRequest.UpdateProjectTeamMember(projectTeamMember.Id, projectTeamMember);
            projectTeamMember.OnRoleChange = OnProjectTeamMemberRoleChange;
        }

        public ProjectViewModel()
        {
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
        }

        public ProjectViewModel(IHttpClient httpClient, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            ProjectTeamMemberRequest = new ProjectTeamMemberRequest(HttpClient);
            GetProject(projectId);

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
        }

        public ProjectViewModel(IAccountRequest accountRequest, string projectId)
        {
            AccountRequest = accountRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProjectById(projectId);
            ProjectTitle = project.Title;
            MemberList = project.ProjectTeam;
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
            var project = App.Current.MainWindow;
            App.Current.MainWindow = home;
            project.Close();
            home.Show();
        }

        private void OnSaveProject(object commandParameter)
        {
            ProjectRequest.UpdateProject(projectId, new Project(ProjectTitle));
            GetProject(projectId);
        }

        private void OnAddTeamMember(object commandParameter)
        {
            ProjectTeamMemberRequest.AddProjectTeamMember(Email, projectId);
            GetProject(projectId);
        }
    }
}
