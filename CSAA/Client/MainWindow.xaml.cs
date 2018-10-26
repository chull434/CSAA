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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.Views;
using Client.Requests;
using CSAA.Models;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var AccountRequest = new AccountRequest();
            var user = new User
            {
                Name = "Test User",
                Email = "testuser@localhost.com",
                Password = "password",
                product_owner = true,
                scrum_master = true,
                developer = true
            };
            AccountRequest.Register(user);
            AccountRequest.Login("testuser@localhost.com", "password");

            var ProjectRequest = new ProjectRequest();
            var project = new Project("My Project");
            ProjectRequest.CreateProject(project);

            //This is for registration testing only remove for login window - JY-MD
            //Registration registration = new Registration();
            //App.Current.MainWindow = registration;
            //this.Close();
            //registration.Show();
        }
    }
}
