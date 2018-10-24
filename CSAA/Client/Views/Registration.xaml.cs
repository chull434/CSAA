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
using CSAA.Models;
using System.ComponentModel.DataAnnotations;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            lbl_InvalidPassword.Visibility = Visibility.Hidden;
            lbl_InvalidFields.Visibility = Visibility.Hidden;

            var ModelStateValid = true;

            ModelStateValid = EmptyFieldValidation();

            if(ModelStateValid)
            {
                ModelStateValid = EmailValidation();
            }

            ModelStateValid = PasswordValidation();

            if (ModelStateValid)
            {
                Register();
            }
        }

        private void Register()
        {
            var AccountRequest = new AccountRequest();
            var user = new User
            {
                Name = txt_FirstName.Text + " " + txt_Surname.Text,
                Email = txt_Email.Text,
                Password = pwb_Input.Password,
                product_owner = chk_ProductOwner.IsChecked.Value,
                scrum_master = chk_ScumMaster.IsChecked.Value,
                developer = chk_Developer.IsChecked.Value
            };
            AccountRequest.Register(user);
        }

        private bool PasswordValidation()
        {
            bool isPasswordInvalid = string.IsNullOrEmpty(pwb_Input.Password) || 
                                     string.IsNullOrEmpty(pwb_Input_Confirm.Password) || 
                                     pwb_Input.Password != pwb_Input_Confirm.Password;

            if (isPasswordInvalid)
            {
                lbl_InvalidPassword.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private bool EmailValidation()
        {
            if (!CheckEmailIsValid(txt_Email.Text))
            {
                lbl_InvalidFields.Content = "Invalid Email";
                lbl_InvalidFields.Visibility = Visibility.Visible;

                return false;
            }

            return true;
        }

        private bool EmptyFieldValidation()
        {
            bool areFieldsEmpty = string.IsNullOrEmpty(txt_FirstName.Text) || 
                                  string.IsNullOrEmpty(txt_Surname.Text) || 
                                  string.IsNullOrEmpty(txt_Email.Text);

            if (areFieldsEmpty)
            {
                lbl_InvalidFields.Content = "Please Populate all fields";
                lbl_InvalidFields.Visibility = Visibility.Visible;

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
