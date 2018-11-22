using Client.Requests;
using Client.ViewModels;
using System.Windows;


namespace Client.Views
{
    /// <summary>
    /// Interaction logic for UserStory.xaml
    /// </summary>
    public partial class UserStory : Window
    {
        public UserStory(IHttpClient client, string userStoryid)
        {
            DataContext = new UserStoryViewModel(client);
            InitializeComponent();
        }
    }
}
