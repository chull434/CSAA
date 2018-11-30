using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;

namespace Client.ViewModels
{
    public class ResetPasswordViewModel : ViewModel
    {
        readonly IHttpClient HttpClient;
        readonly IAccountRequest AccountRequest;

        public string Email { get; set; }

        string _emailErrors;
        public string EmailError
        {
            get => _emailErrors;
            set => SetProperty(ref _emailErrors, value);
        }

        
        private readonly DelegateCommand _login;
        public ICommand Login => _login;

        private readonly DelegateCommand _resetPassword;
        public ICommand ResetPassword => _resetPassword;

        public ResetPasswordViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            _login = new DelegateCommand(OnLogin);
            _resetPassword = new DelegateCommand(OnResetPassword);
        }

        public ResetPasswordViewModel(IAccountRequest accountRequest)
        {
            AccountRequest = accountRequest;
            _login = new DelegateCommand(OnLogin);
            _resetPassword = new DelegateCommand(OnResetPassword);
        }

        public void OnResetPassword(object commandParameter)
        {
            EmailError = "";

            var ModelStateValid = EmptyFieldValidation();
            if (!ModelStateValid) return;
            ModelStateValid = EmailValidation();
            if (!ModelStateValid) return;
            AccountRequest.ResetPassword(Email);

            ChangeView(new Login(HttpClient));
        }


        private bool EmptyFieldValidation()
        {
            bool isEmailFieldEmpty = string.IsNullOrEmpty(Email);
 
            if (isEmailFieldEmpty)
            {
                EmailError = "Please populate email field.";
                return false;
            }

            return true;
        }

        private bool EmailValidation()
        {
            if (!CheckEmailIsValid(Email))
            {
                EmailError = "Invalid email.";
                return false;
            }

            return true;
        }

        private bool CheckEmailIsValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private void OnLogin(object commandParameter)
        {
            ChangeView(new Login(HttpClient));
        }


    }
}