using System;
using System.Windows.Input;
using System.Collections.Generic;
using Client.Requests;
using Client.Views;
using CSAA.Enums;
using CSAA.ServiceModels;
using Project = CSAA.ServiceModels.Project;
using Sprint = CSAA.ServiceModels.Sprint;

namespace Client.ViewModels
{
    public class ProjectViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IProjectTeamMemberRequest ProjectTeamMemberRequest;
        readonly ISprintRequest SprintRequest;
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

        private readonly DelegateCommand _searchTeamMember;
        public ICommand SearchTeamMember => _searchTeamMember;

        private readonly DelegateCommand _viewBacklog;
        public ICommand ViewBacklog => _viewBacklog;

        private readonly DelegateCommand _newSprint;
        public ICommand NewSprint => _newSprint;

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

        string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        bool _productOwner;
        public bool ProductOwner
        {
            get => _productOwner;
            set => SetProperty(ref _productOwner, value);
        }

        bool _scrumMaster;
        public bool ScrumMaster
        {
            get => _scrumMaster;
            set => SetProperty(ref _scrumMaster, value);
        }

        bool _developer;
        public bool Developer
        {
            get => _developer;
            set => SetProperty(ref _developer, value);
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

        List<User> _userList = new List<User>();
        public List<User> UserList
        {
            get => _userList;
            set
            {
                value.ForEach(m => m.OnRoleChange = OnUserRoleChange);
                SetProperty(ref _userList, value);
            }
        }

        List<Sprint> _sprintList = new List<Sprint>();
        public List<Sprint> SprintList
        {
            get => _sprintList;
            set
            {
                //value.ForEach(m => m.OnRoleChange = OnUserRoleChange);
                SetProperty(ref _sprintList, value);
            }
        }

        Sprint _selectedSprint = new Sprint();
        public Sprint SelectedSprint
        {
            set
            {
                OnOpenSprint(value.Id);
            }
        }

        public bool IsProjectManager { get; set; }
        public bool IsScrumMaster { get; set; }

        public ProjectViewModel(IHttpClient httpClient, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            ProjectTeamMemberRequest = new ProjectTeamMemberRequest(HttpClient);
            SprintRequest = new SprintRequest(HttpClient);
            GetProject(projectId);

            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
            _searchTeamMember = new DelegateCommand(OnSearchTeamMember);
            _viewBacklog = new DelegateCommand(OnViewBacklog);
            _newSprint = new DelegateCommand(OnNewSprint);
        }

        public ProjectViewModel(IAccountRequest accountRequest, IProjectRequest projectRequest, IProjectTeamMemberRequest projectTeamMemberRequest, ISprintRequest sprintRequest, string Id)
        {
            AccountRequest = accountRequest;
            ProjectRequest = projectRequest;
            ProjectTeamMemberRequest = projectTeamMemberRequest;
            SprintRequest = sprintRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
            _searchTeamMember = new DelegateCommand(OnSearchTeamMember);
            _viewBacklog = new DelegateCommand(OnViewBacklog);
            _newSprint = new DelegateCommand(OnNewSprint);
            projectId = Id;
        }

        private void GetProject(string projectId)
        {
            this.projectId = projectId;
            var project = ProjectRequest.GetProject(projectId);
            ProjectTitle = project.Title;
            MemberList = project.ProjectTeam;
            SprintList = project.Sprints;
            IsProjectManager = project.IsProjectManager;
            IsScrumMaster = project.IsScrumMaster;
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
            ProjectTeamMemberRequest.AddProjectTeamMember(Email, projectId, Role.TeamMember);
            GetProject(projectId);
        }

        private void OnSearchTeamMember(object commandParameter)
        {
            var user = new User
            {
                Name = UserName,
                Email = Email,
                Description = Description,
                product_owner = ProductOwner,
                scrum_master = ScrumMaster,
                developer = Developer
            };
            UserList = ProjectTeamMemberRequest.SearchProjectTeamMembers(projectId, user);
        }

        public void OnProjectTeamMemberRoleChange(ProjectTeamMember projectTeamMember)
        {
            projectTeamMember.OnRoleChange = null;
            ProjectTeamMemberRequest.UpdateProjectTeamMember(projectTeamMember.Id, projectTeamMember);
            GetProject(projectId);
            projectTeamMember.OnRoleChange = OnProjectTeamMemberRoleChange;
        }

        public void OnUserRoleChange(User user)
        {
            user.OnRoleChange = null;
            ProjectTeamMemberRequest.AddProjectTeamMember(user.Email, projectId, user.Role);
            GetProject(projectId);
            SearchTeamMember.Execute(null);
            user.OnRoleChange = OnUserRoleChange;
        }

        private void OnViewBacklog(object commandParameter)
        {
            ChangeView(new ProductBacklog(HttpClient, projectId));
        }

        private void OnNewSprint(object commandParameter)
        {
            var sprintId = SprintRequest.CreateSprint(new Sprint("Sprint 1", projectId, DateTime.Today, DateTime.Today.AddDays(14)));
            ChangeView(new Views.Sprint(HttpClient, sprintId, projectId));
        }

        private void OnOpenSprint(string sprintId)
        {
            ChangeView(new Views.Sprint(HttpClient, sprintId, projectId));
        }
    }
}
