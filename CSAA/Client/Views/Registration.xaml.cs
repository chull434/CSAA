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
using Client.ViewModels;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration(IHttpClient client)
        {
            DataContext = new RegistrationViewModel(client);
            InitializeComponent();
        }
    }
}
