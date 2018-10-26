using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.Requests;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Window
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            //TODO send user name and password to server
            lbl_EmailError.Visibility = Visibility.Hidden;
            lbl_PasswordError.Visibility = Visibility.Hidden;

            var ModelStateValid = true;

            ModelStateValid = EmptyFieldValidation();
            if (ModelStateValid == true)
            {
                var loginAccountRequest = new AccountRequest();
                loginAccountRequest.Login(txt_Email.Text, pwb_Input.Password);
            }
            

        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            //TODO Hint or email sent to user to reset password
            Registration registration = new Registration();
            App.Current.MainWindow = registration;
            this.Close();
            registration.Show();

        }

        //Validation

        private bool EmptyFieldValidation()
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(txt_Email.Text);
            bool arePasswordEmpty = string.IsNullOrEmpty(pwb_Input.Password.ToString());

            if (isUsernameEmpty)
            {
                lbl_EmailError.Content = "Populate username field";
                lbl_EmailError.Visibility = Visibility.Visible;

                return false;
            }

            if (arePasswordEmpty)
            {
                lbl_PasswordError.Content = "Please enter you password";
                lbl_PasswordError.Visibility = Visibility.Visible;

                return false;
            }

            return true;
        }


    }
}
