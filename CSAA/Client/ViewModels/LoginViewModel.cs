using System.Windows.Input;
using Client.Requests;
using Client.Views;

namespace Client.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        readonly IHttpClient HttpClient;
        readonly IAccountRequest AccountRequest;

        public string Email { get; set; }
        public string Password { get; set; }
        
        string _passwordError;
        public string PasswordError
        {
            get => _passwordError;
            set => SetProperty(ref _passwordError, value);
        }

        string _emailErrors;
        public string EmailError
        {
            get => _emailErrors;
            set => SetProperty(ref _emailErrors, value);
        }

        private readonly DelegateCommand _login;
        public ICommand Login => _login;

        private readonly DelegateCommand _register;
        public ICommand Register => _register;

        public LoginViewModel()
        {
            _login = new DelegateCommand(OnLogin);
            _register = new DelegateCommand(OnRegister);
        }

        public LoginViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            _login = new DelegateCommand(OnLogin);
            _register = new DelegateCommand(OnRegister);
        }

        public LoginViewModel(IAccountRequest accountRequest)
        {
            AccountRequest = accountRequest;
            _login = new DelegateCommand(OnLogin);
            _register = new DelegateCommand(OnRegister);
        }

        private void OnRegister(object commandParameter)
        {
            var registration = new Registration(HttpClient);
            var login = App.Current.MainWindow;
            App.Current.MainWindow = registration;
            login.Close();
            registration.Show();
        }

        private void OnLogin(object commandParameter)
        {
            EmailError = "";
            PasswordError = "";

            var ModelStateValid = EmptyFieldValidation();
            if (!ModelStateValid) return;

            var errorMessage = AccountRequest.Login(Email, Password);
            if (errorMessage != "")
            {
                PasswordError = errorMessage;
                return;
            }

            var home = new Home(HttpClient);
            var login = App.Current.MainWindow;
            App.Current.MainWindow = home;
            login.Close();
            home.Show();
        }

        private bool EmptyFieldValidation()
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(Email);
            bool arePasswordEmpty = string.IsNullOrEmpty(Password);

            if (isUsernameEmpty)
            {
                EmailError = "Please populate email field.";
                return false;
            }

            if (arePasswordEmpty)
            {
                PasswordError = "Please enter you password.";
                return false;
            }

            return true;
        }
    }
}
