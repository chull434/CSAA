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

        public bool IsProjectManager { get; set; }

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

        public ProjectViewModel(IAccountRequest accountRequest, IProjectRequest projectRequest, IProjectTeamMemberRequest projectTeamMemberRequest, string Id)
        {
            AccountRequest = accountRequest;
            ProjectRequest = projectRequest;
            ProjectTeamMemberRequest = projectTeamMemberRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
            projectId = Id;
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProject(projectId);
            ProjectTitle = project.Title;
            MemberList = project.ProjectTeam;
            IsProjectManager = project.IsProjectManager;
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

        public void OnProjectTeamMemberRoleChange(ProjectTeamMember projectTeamMember)
        {
            projectTeamMember.OnRoleChange = null;
            ProjectTeamMemberRequest.UpdateProjectTeamMember(projectTeamMember.Id, projectTeamMember);
            GetProject(projectId);
            projectTeamMember.OnRoleChange = OnProjectTeamMemberRoleChange;
        }
    }
}
