using Client.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class ProfileViewModel: ViewModel
    {
        readonly IAccountRequest AccountRequest;
        readonly IHttpClient HttpClient;

        private readonly DelegateCommand _save;
        public ICommand Save => _save;

        public ProfileViewModel(IHttpClient httpClient)
        {
            HttpClient = httpClient;
            AccountRequest = new AccountRequest(httpClient);
            _save = new DelegateCommand(OnSave);
            GetUser();
        }

        private void OnSave(object commandParameter)
        {
            AccountRequest.Save();
        }

        private void GetUser()
        {
            var user = AccountRequest.GetUser();
            
        }
    }
}
