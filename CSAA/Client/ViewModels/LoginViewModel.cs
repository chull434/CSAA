using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Requests;

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

        string _fieldErrors;
        public string FieldsError
        {
            get => _fieldErrors;
            set => SetProperty(ref _fieldErrors, value);
        }

        private readonly DelegateCommand _login;
        public ICommand Login => _login;

        public LoginViewModel()
        {
            AccountRequest = new AccountRequest();
            _login = new DelegateCommand(OnLogin);
        }

        public LoginViewModel(IAccountRequest AccountRequest)
        {
            this.AccountRequest = AccountRequest;
            _login = new DelegateCommand(OnLogin);
        }

        private void OnLogin(object commandParameter)
        {
            FieldsError = "";
            PasswordError = "";

            var ModelStateValid = EmptyFieldValidation();
            if (ModelStateValid == true)
            {
                AccountRequest.Login(Email, Password);
            }
        }

        private bool EmptyFieldValidation()
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(Email);
            bool arePasswordEmpty = string.IsNullOrEmpty(Password);

            if (isUsernameEmpty)
            {
                FieldsError = "Populate username field.";
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
