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

        private bool CheckEmail(String email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            lbl_InvalidPassword.Visibility = Visibility.Hidden;
            lbl_InvalidFields.Visibility = Visibility.Hidden;
            String firstName = txt_FirstName.Text;
            String secondName = txt_Surname.Text;

            //check for empty fields
            if (!(string.IsNullOrEmpty(txt_FirstName.Text.ToString())) && !(string.IsNullOrEmpty(txt_Surname.Text.ToString())) && !(string.IsNullOrEmpty(txt_Email.Text.ToString())))
            {
                //check if email format is valid
                if (CheckEmail(txt_Email.Text))
                {
                    //check if password field is populated and passwords match
                    if (!(string.IsNullOrEmpty(pwb_Input.Password) && string.IsNullOrEmpty(pwb_Input_Confirm.Password)) && pwb_Input.Password == pwb_Input_Confirm.Password)
                    {   
                        //Register new user with fields
                        var AccountRequest = new AccountRequest();
                        var user = new User
                        {
                            Name = firstName + " " + secondName,
                            Email = txt_Email.Text,
                            Password = pwb_Input.Password,
                            product_owner = chk_ProductOwner.IsChecked.Value,
                            scrum_master = chk_ScumMaster.IsChecked.Value,
                            developer = chk_Developer.IsChecked.Value
                        };
                        AccountRequest.Register(user);
                    }
                    else
                    {
                        //System.Windows.MessageBox.Show("Passwords do not match");
                        lbl_InvalidPassword.Visibility = Visibility.Visible;
                    }
                } 
                else
                {
                    //System.Windows.MessageBox.Show("Invalid Email");
                    lbl_InvalidFields.Content = "Invalid Email";
                    lbl_InvalidFields.Visibility = Visibility.Visible;
                }
            }
            else
            {
                //System.Windows.MessageBox.Show("Please populate all fields");
                lbl_InvalidFields.Content = "Please Populate all fields";
                lbl_InvalidFields.Visibility = Visibility.Visible;
            }
        }
    }
}
