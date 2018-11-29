using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Requests;
using Client.Views;
using Sprint = CSAA.ServiceModels.Sprint;

namespace Client.ViewModels
{
    public class SprintViewModel : ViewModel
    {
        readonly ISprintRequest SprintRequest;
        readonly IAccountRequest AccountRequest;
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

        public SprintViewModel(IHttpClient httpClient, string sprintId, string projectId)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            SprintRequest = new SprintRequest(HttpClient);
            GetSprint(sprintId);
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveSprint = new DelegateCommand(OnSaveSprint);
            _back = new DelegateCommand(OnBack);
            this.projectId = projectId;
        }

        public SprintViewModel(IAccountRequest accountRequest, ISprintRequest sprintRequest, string sprintId, string projectId)
        {
            AccountRequest = accountRequest;
            SprintRequest = sprintRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _saveSprint = new DelegateCommand(OnSaveSprint);
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
    }
}
