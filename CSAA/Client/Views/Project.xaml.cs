using System.Windows;
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
