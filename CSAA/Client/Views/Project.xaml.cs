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
using Client.ViewModels;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Window
    {
        public Project(IHttpClient client, string projectId)
        {
            DataContext = new ProjectViewModel(client, projectId);
            InitializeComponent();
        }
    }
}
