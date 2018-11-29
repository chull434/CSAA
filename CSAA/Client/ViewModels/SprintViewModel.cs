using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using Sprint = CSAA.ServiceModels.Sprint;

namespace Client.ViewModels
{
    public class SprintViewModel : ViewModel
    {
        readonly ISprintRequest SprintRequest;
        readonly IAccountRequest AccountRequest;
        readonly IProjectTeamMemberRequest ProjectTeamMemberRequest;
        readonly ISprintTeamMemberRequest SprintTeamMemberRequest;
        readonly IHttpClient HttpClient;

        string sprintId;
        string projectId;

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _saveSprint;
        public ICommand SaveSprint => _saveSprint;

        private readonly DelegateCommand _back;
        public ICommand Back => _back;

        private readonly DelegateCommand _searchTeamMember;
        public ICommand SearchTeamMember => _searchTeamMember;

        string _sprintTitle;
        public string SprintTitle
        {
            get => _sprintTitle;
            set => SetProperty(ref _sprintTitle, value);
        }

        DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
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

        List<SprintTeamMember> _memberList = new List<SprintTeamMember>();
        public List<SprintTeamMember> MemberList
        {
            get => _memberList;
            set
            {
                SetProperty(ref _memberList, value);
            }
        }

        List<User> _userList = new List<User>();
        public List<User> UserList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }

        User _selectedUser = new User();
        public User SelectedUser
        {
            set => OnAddToSprint(value);
        }

        public bool IsScrumMaster { get; set; }

        public SprintViewModel(IHttpClient httpClient, string sprintId, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            ProjectTeamMemberRequest = new ProjectTeamMemberRequest(HttpClient);
            SprintTeamMemberRequest = new SprintTeamMemberRequest(HttpClient);
            SprintRequest = new SprintRequest(HttpClient);
            GetSprint(sprintId);
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveSprint = new DelegateCommand(OnSaveSprint);
            _searchTeamMember = new DelegateCommand(OnSearchTeamMember);
            _back = new DelegateCommand(OnBack);
            this.projectId = projectId;
        }

        public SprintViewModel(IAccountRequest accountRequest, IProjectTeamMemberRequest projectTeamMemberRequest, ISprintRequest sprintRequest, ISprintTeamMemberRequest sprintTeamMemberRequest, string sprintId, string projectId)
        {
            AccountRequest = accountRequest;
            ProjectTeamMemberRequest = projectTeamMemberRequest;
            SprintRequest = sprintRequest;
            SprintTeamMemberRequest = sprintTeamMemberRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveSprint = new DelegateCommand(OnSaveSprint);
            _searchTeamMember = new DelegateCommand(OnSearchTeamMember);
            _back = new DelegateCommand(OnBack);
            this.sprintId = sprintId;
            this.projectId = projectId;
        }

        private void GetSprint(string sprintId)
        {
            this.sprintId = sprintId;
            var sprint = SprintRequest.GetSprint(sprintId);
            SprintTitle = sprint.Title;
            StartDate = sprint.StartDate;
            EndDate = sprint.EndDate;
            MemberList = sprint.SprintTeam;
            IsScrumMaster = sprint.IsScrumMaster;
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

        private void OnSaveSprint(object commandParameter)
        {
            var sprint = new Sprint
            {
                Title = SprintTitle,
                StartDate = StartDate,
                EndDate = EndDate
            };
            SprintRequest.UpdateSprint(sprintId, sprint);
            GetSprint(sprintId);
        }

        private void OnBack(object commandParameter)
        {
            ChangeView(new Views.Project(HttpClient, projectId));
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
            UserList = ProjectTeamMemberRequest.SearchProjectTeamMembersSprint(projectId, sprintId, user);
        }

        public void OnAddToSprint(User user)
        {
            if (user == null) return;
            SprintTeamMemberRequest.AddSprintTeamMember(new SprintTeamMember(sprintId, user.ProjectTeamMemberId));
            GetSprint(sprintId);
            SearchTeamMember.Execute(null);
        }
    }
}
