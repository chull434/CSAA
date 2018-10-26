using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Requests;
using Client.Views;

namespace Client.ViewModels
{
    public class LoginViewModel : ViewModel
    {
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
            AccountRequest = new AccountRequest();
            _login = new DelegateCommand(OnLogin);
            _register = new DelegateCommand(OnRegister);
        }

        public LoginViewModel(IAccountRequest AccountRequest)
        {
            this.AccountRequest = AccountRequest;
            _login = new DelegateCommand(OnLogin);
            _register = new DelegateCommand(OnRegister);
        }

        private void OnRegister(object commandParameter)
        {
            var registration = new Registration();
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
            if (ModelStateValid == true)
                if (AccountRequest.Login(Email, Password))
                {
                    var home = new Home();
                    var login = App.Current.MainWindow;
                    App.Current.MainWindow = home;
                    login.Close();
                    home.Show();
                }
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
