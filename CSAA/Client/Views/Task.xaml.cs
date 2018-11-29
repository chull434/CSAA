using Client.Requests;
using Client.ViewModels;
using System.Windows;


namespace Client.Views
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        public Task(IHttpClient client, string taskId, string userStoryId, string projectId)
        {
            DataContext = new TaskViewModel(client, taskId, userStoryId, projectId);
            InitializeComponent();
        }
    }
}
