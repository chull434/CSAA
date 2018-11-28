using Client.Requests;
using Client.ViewModels;
using System.Windows;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for ProductBacklog.xaml
    /// </summary>
    public partial class ProductBacklog : Window
    {
        public ProductBacklog(IHttpClient client, string projectId)
        {
            DataContext = new ProductBacklogViewModel(client, projectId);
            InitializeComponent();
        }
    }
}
