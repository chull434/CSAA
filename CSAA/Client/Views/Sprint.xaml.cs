using System.Windows;
using Client.Requests;
using Client.ViewModels;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Sprint.xaml
    /// </summary>
    public partial class Sprint : Window
    {
        public Sprint(IHttpClient client, string sprintId, string projectId)
        {
            DataContext = new SprintViewModel(client, sprintId, projectId);
            InitializeComponent();
        }
    }
}
