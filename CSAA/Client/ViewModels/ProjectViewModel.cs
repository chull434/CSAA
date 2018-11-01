using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using Client.Views;

namespace Client.ViewModels
{
    class ProjectViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IProjectTeamMemberRequest ProjectTeamMemberRequest;
        readonly IHttpClient HttpClient;

        private readonly DelegateCommand _homeBtn;
        public ICommand HomeBtn => _homeBtn;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _saveProject;
        public ICommand SaveProject => _saveProject;

        private readonly DelegateCommand _addTeamMember;
        public ICommand AddTeamMember => _addTeamMember;

        string _projectID;
        public string ProjectID
        {
            get => _projectID;
            set => SetProperty(ref _projectID, value);
        }

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

        List<TeamMembers> _memberList = new List<TeamMembers>();
        public List<TeamMembers> MemberList
        {
            get => _memberList;
            set => SetProperty(ref _memberList, value);
        }
        public ProjectViewModel(IHttpClient httpClient, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            ProjectTeamMemberRequest = new ProjectTeamMemberRequest(HttpClient);
            this.ProjectID = projectId;
            //var project = ProjectRequest.GetProjectById(projectId);//todo
            
            _homeBtn = new DelegateCommand(OnHomeBtn);
            _logout = new DelegateCommand(OnLogout);
            _saveProject = new DelegateCommand(OnSaveProject);
            _addTeamMember = new DelegateCommand(OnAddTeamMember);
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

        private void OnHomeBtn(object commandParameter)
        {
            var home = new Home(HttpClient);
            var project = App.Current.MainWindow;
            App.Current.MainWindow = home;
            project.Close();
            home.Show();
        }

        private void OnSaveProject(object commandParameter)
        {
            //ProjectRequest.//todo
        }

        private void OnAddTeamMember(object commandParameter)
        {
            ProjectTeamMemberRequest.AddTeamMember(Email, ProjectID);
        }
    }
}
