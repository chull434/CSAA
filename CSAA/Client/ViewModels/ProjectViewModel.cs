using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Requests;
using Client.Views;
using CSAA.Models;

namespace Client.ViewModels
{
    class ProjectViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IHttpClient HttpClient;

        private readonly DelegateCommand _homeBtn;
        public ICommand HomeBtn => _homeBtn;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

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

        string _projectManager;
        public string ProjectManager
        {
            get => _projectManager;
            set => SetProperty(ref _projectManager, value);
        }

        string _projectOwner;
        public string ProjectOwner
        {
            get => _projectOwner;
            set => SetProperty(ref _projectOwner, value);
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
            this.ProjectID = projectId;
            var project = ProjectRequest.GetProjectById(projectId);
            
            _homeBtn = new DelegateCommand(OnHomeBtn);
            _logout = new DelegateCommand(OnLogout);
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
    }
}
