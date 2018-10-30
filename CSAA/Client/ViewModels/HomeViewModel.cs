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
    public class HomeViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IHttpClient HttpClient;

        List<Project> _projectList = new List<Project>();
        public List<Project> ProjectList
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

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _createProject;
        public ICommand CreateProject => _createProject;

        public HomeViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            _logout = new DelegateCommand(OnLogout);
            _createProject = new DelegateCommand(OnCreateProject);

            ProjectList.Add(new Project() { Title = "Project A", Completion = 20 });
            ProjectList.Add(new Project() { Title = "Project B", Completion = 80 });
            ProjectList.Add(new Project() { Title = "Project C", Completion = 55 });;

            AssignedTasks.Add(new Task() { Title = "Task 1", Project = "Project A" });
            AssignedTasks.Add(new Task() { Title = "Task 2", Project = "Project A" });
            AssignedTasks.Add(new Task() { Title = "Task 3", Project = "Project A" });
        }

        private void OnLogout(object commandParameter)
        {
            var login = new Login(HttpClient);
            var home = App.Current.MainWindow;
            App.Current.MainWindow = login;
            home.Close();
            login.Show();
        }

        private void OnCreateProject(object commandParameter)
        {

        }
    }
    public class Project
    { 
        public string Title { get; set; }
        public int Completion { get; set; }
    }

    public class Task
    {
        public string Title { get; set; }
        public string Project { get; set; }
    }
}
