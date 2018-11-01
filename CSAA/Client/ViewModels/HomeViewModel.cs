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
    public class HomeViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IProjectRequest ProjectRequest;
        readonly IHttpClient HttpClient;

        List<Projects> _projectList = new List<Projects>();
        public List<Projects> ProjectList
        {
            get => _projectList;
            set => SetProperty(ref _projectList, value);
        }

        List<Task> _assignedTasks = new List<Task>();
        public List<Task> AssignedTasks
        {
            get => _assignedTasks;
            set => SetProperty(ref _assignedTasks, value);
        }

        List<TeamMembers> _memberList = new List<TeamMembers>();
        public List<TeamMembers> MemberList
        {
            get => _memberList;
            set => SetProperty(ref _memberList, value);
        }

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _createProject;
        public ICommand CreateProject => _createProject;

        public HomeViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            ProjectRequest = new ProjectRequest(httpClient);
            _logout = new DelegateCommand(OnLogout);
            _createProject = new DelegateCommand(OnCreateProject);

            ProjectList.Add(new Projects() { Title = "Project A", Completion = 20 });
            ProjectList.Add(new Projects() { Title = "Project B", Completion = 80 });
            ProjectList.Add(new Projects() { Title = "Project C", Completion = 55 });;

            AssignedTasks.Add(new Task() { Title = "Task 1", Project = "Project A" });
            AssignedTasks.Add(new Task() { Title = "Task 2", Project = "Project A" });
            AssignedTasks.Add(new Task() { Title = "Task 3", Project = "Project A" });

            MemberList.Add(new TeamMembers() { Name = "Johnston York", Project = "Project A", Email = "jyork@test.com", Role = "Developer" });
            MemberList.Add(new TeamMembers() { Name = "Michael Dyer", Project = "Project A", Email = "mdyer@test.com", Role = "Developer" });
            MemberList.Add(new TeamMembers() { Name = "Chris Hull", Project = "Project A", Email = "chull@test.com", Role = "Scrum Master" });
            MemberList.Add(new TeamMembers() { Name = "Jamie-Leigh McMullan", Project = "Project A", Email = "jmcmullan@test.com", Role = "Developer" });
            MemberList.Add(new TeamMembers() { Name = "Keith Harris", Project = "Project A", Email = "kharris@test.com", Role = "Developer" });
            MemberList.Add(new TeamMembers() { Name = "Richard McClelland", Project = "Project A", Email = "rmcclelland@test.com", Role = "Developer" });
            MemberList.Add(new TeamMembers() { Name = "Darragh Walls", Project = "Project A", Email = "dwalls@test.com", Role = "Developer" });
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

        private void OnCreateProject(object commandParameter)
        {
            var project = new CSAA.DataModels.Project("New Project");
            ProjectRequest.CreateProject(project);

            var projectWindow = new Views.Project(HttpClient, project.Id.ToString());
            var currentWindow = App.Current.MainWindow;
            App.Current.MainWindow = projectWindow;
            currentWindow.Close();
            projectWindow.Show();
        }
    }

    public class Projects
    { 
        public string Title { get; set; }
        public int Completion { get; set; }
    }

    public class Task
    {
        public string Title { get; set; }
        public string Project { get; set; }
    }

    public class TeamMembers
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Project { get; set; }
        public string Role { get; set; }
    }
}
