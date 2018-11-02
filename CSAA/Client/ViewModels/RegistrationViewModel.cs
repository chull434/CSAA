using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Client.Requests;
using Client.Views;
using CSAA.ServiceModels;

namespace Client.ViewModels
{
    public class RegistrationViewModel : ViewModel
    {
        readonly IHttpClient HttpClient;
        readonly IAccountRequest AccountRequest;

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool ProductOwner { get; set; }
        public bool ScumMaster { get; set; }
        public bool Developer { get; set; }

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

        private readonly DelegateCommand _register;
        public ICommand Register => _register;

        private readonly DelegateCommand _login;
        public ICommand Login => _login;

        public RegistrationViewModel()
        {
            _register = new DelegateCommand(OnRegister);
            _login = new DelegateCommand(OnLogin);
        }

        public RegistrationViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            _register = new DelegateCommand(OnRegister);
            _login = new DelegateCommand(OnLogin);
        }

        public RegistrationViewModel(IAccountRequest accountRequest)
        {
            AccountRequest = accountRequest;
            _register = new DelegateCommand(OnRegister);
            _login = new DelegateCommand(OnLogin);
        }

        private void OnLogin(object commandParameter)
        {
            var login = new Login(HttpClient);
            var registration = App.Current.MainWindow;
            App.Current.MainWindow = login;
            login.Show();
            registration.Close();
        }

        private void OnRegister(object commandParameter)
        {
            FieldsError = "";
            PasswordError = "";

            var FieldsValid = EmptyFieldValidation();
            var EmailValid = false;
            if (FieldsValid) EmailValid = EmailValidation();
            var PasswordValid = PasswordValidation();

            if (FieldsValid && EmailValid && PasswordValid)
                if (RegisterUser())
                    OnLogin(null);
        }

        private bool RegisterUser()
        {
            var user = new User
            {
                Name = FirstName + " " + Surname,
                Email = Email,
                Password = Password,
                product_owner = ProductOwner,
                scrum_master = ScumMaster,
                developer = Developer
            };
            var errorMessage = AccountRequest.Register(user);

            if (errorMessage != "")
            {
                FieldsError = errorMessage;
                return false;
            }

            return true;
        }

        private bool PasswordValidation()
        {
            bool isPasswordInvalid = string.IsNullOrEmpty(Password) ||
                                     string.IsNullOrEmpty(ConfirmPassword) ||
                                     Password != ConfirmPassword;

            if (isPasswordInvalid)
            {
                PasswordError = "Passwords do not match.";
                return false;
            }

            return true;
        }

        private bool EmailValidation()
        {
            if (!CheckEmailIsValid(Email))
            {
                FieldsError = "Invalid email.";
                return false;
            }

            return true;
        }

        private bool EmptyFieldValidation()
        {
            bool areFieldsEmpty = string.IsNullOrEmpty(FirstName) ||
                                  string.IsNullOrEmpty(Surname) ||
                                  string.IsNullOrEmpty(Email);

            if (areFieldsEmpty)
            {
                FieldsError = "Please populate all fields.";
                return false;
            }

            return true;
        }

        private bool CheckEmailIsValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
