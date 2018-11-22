
using System.Windows.Input;
using System.Collections.Generic;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;
using UserStory = CSAA.ServiceModels.UserStory;

namespace Client.ViewModels
{
    class UserStoryViewModel : ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IUserStoryRequest UserStoryRequest;      
        readonly IHttpClient HttpClient;       

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        string _userStoryTitle;
        public string UserStoryTitle
        {
            get => _userStoryTitle;
            set => SetProperty(ref _userStoryTitle, value);
        }

        string _userStoryDescription;
        public string UserStoryDescription
        {
            get => _userStoryDescription;
            set => SetProperty(ref _userStoryDescription, value);
        }
   

        public UserStoryViewModel()
        {
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
        }

        public UserStoryViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            UserStoryRequest = new UserStoryRequest(httpClient);          

            _home = new DelegateCommand(OnHome);
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

        private void OnHome(object commandParameter)
        {
            var home = new Home(HttpClient);
            var userStory = App.Current.MainWindow;
            App.Current.MainWindow = home;
            userStory.Close();
            home.Show();
        }
    }
}
