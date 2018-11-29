using Client.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Client.Views;
using CSAA.ServiceModels;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace Client.ViewModels
{
    public class ProfileViewModel: ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IHttpClient HttpClient;

        string userId;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool ProductOwner { get; set; }
        public bool ScrumMaster { get; set; }
        public bool Developer { get; set; }

        BitmapImage _profile;
        public BitmapImage Profile
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }

        private readonly DelegateCommand _save;
        public ICommand Save => _save;

        private readonly DelegateCommand _logout;
        public ICommand Logout => _logout;

        private readonly DelegateCommand _home;
        public ICommand Home => _home;

        private readonly DelegateCommand _upload;
        public ICommand Upload => _upload;

        public ProfileViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _save = new DelegateCommand(OnSave);
            _upload = new DelegateCommand(OnUpload);
            GetUser();
        }

        public ProfileViewModel(IHttpClient httpClient, IAccountRequest accountRequest)
        {
            HttpClient = httpClient;
            AccountRequest = accountRequest;
            _home = new DelegateCommand(OnHome);
            _logout = new DelegateCommand(OnLogout);
            _save = new DelegateCommand(OnSave);
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

        private void OnSave(object commandParameter)
        {
            var user = new User
            {
                Name = Name,
                Email = Email,
                Description = Description,
                product_owner = ProductOwner,
                scrum_master = ScrumMaster,
                developer = Developer,
                Profile = Profile.UriSource.AbsolutePath
            };
            AccountRequest.Save(userId, user);
        }

        private void OnUpload(object commandParameter)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                Profile = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void GetUser()
        {
            var user = AccountRequest.GetUser();
            userId = user.Id;
            Name = user.Name;
            Email = user.Email;
            Description = user.Description;
            ProductOwner = user.product_owner;
            ScrumMaster = user.scrum_master;
            Developer = user.developer;
            if (user.Profile != null) Profile = new BitmapImage(new Uri(user.Profile));
        }
    }
}
